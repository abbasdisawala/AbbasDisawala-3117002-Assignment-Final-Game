using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameover : MonoBehaviour
{
    public GameObject FailPannel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("Player"))
        {
            FailPannel.SetActive(true);
            Time.timeScale=0;
        }
         
}
}