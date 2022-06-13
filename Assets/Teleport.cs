using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{
    public bool canTele = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.tag == "Player" ) { 
            if (canTele) {
                canTele = false;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
        
    }
}