using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finishpoint : MonoBehaviour
{
    public GameObject WinPannel;
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
            WinPannel.SetActive(true);
            Time.timeScale=0;
        }
}
}
