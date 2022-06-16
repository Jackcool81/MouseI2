using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceField : MonoBehaviour
{
   
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("hello");
        if (col.gameObject.tag == "Player")
        {
            AkSoundEngine.PostEvent("Force", gameObject); //must include specfic name of event
        }
    }
}
