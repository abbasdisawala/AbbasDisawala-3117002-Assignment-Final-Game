using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BasicCharacterController : MonoBehaviour
{
    public int playerLives = 3;
    //movement variables
    public float moveForce;
    public float maxSpeed;
    private Rigidbody playerRigidbody;

    //rotation variables
    public GameObject child;
    public float rotateSpeed;
    public float rotationSensitivity;

    //animation variables
    public Animator playerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //move code starts
        if (Mathf.Abs(playerRigidbody.velocity.magnitude) < maxSpeed)
        {
            playerRigidbody.AddForce((Input.GetAxis("Horizontal") * moveForce), 0, (Input.GetAxis("Vertical") * moveForce));
        }
        //move code ends

        //rotation code starts
        Vector3 moveDirection = new Vector3(playerRigidbody.velocity.x, 0, playerRigidbody.velocity.z);
        if (moveDirection.magnitude > rotationSensitivity)
        {
            child.transform.rotation = Quaternion.Slerp(child.transform.rotation, Quaternion.LookRotation(moveDirection), Time.deltaTime * rotateSpeed);
        }
        //rotation code ends

        //animation code begins
        playerAnimator.SetFloat("speed", moveDirection.magnitude);
        playerAnimator.SetFloat("verticalSpeed", playerRigidbody.velocity.y);

    }

    // Collision detection for losing lives
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            LoseLife();
        }
    }

    private void LoseLife()
    {
        playerLives--;

        // Additional logic can be added here, such as updating UI to display remaining lives.

        // Check if the player has run out of lives
        if (playerLives <= 0)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        // You can reload the scene or perform any other game over logic here
        // For example, reloading the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
