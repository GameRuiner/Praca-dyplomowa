using System.Collections;
using System.Collections.Generic;
using UnityEngine;  


public class Collision : MonoBehaviour
{
    private GameManager gameManager;

    void Start()
    {
        //gameManager = GameObject.Find("GameManager");
        gameManager = GameObject.FindObjectOfType(typeof(GameManager)) as GameManager;

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "checkPoint") {
            other.GetComponent<Collider>().enabled = false;
            gameManager.collisionToPass -= 1;
        }
        if (other.tag == "failPoint") {
            other.GetComponent<Collider>().enabled = false;
            gameManager.levelFailed = true;
        }         
    }
}
