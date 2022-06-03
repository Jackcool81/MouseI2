using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Make sure that the interactable object has a box collider
[RequireComponent(typeof(BoxCollider2D))]
//ALl interactable objects inherit from this class
public abstract class Interactable : MonoBehaviour
{
    RaycastHit2D raycast;
    public bool interacted;


    private void Reset()
    {
        //since object has a boxcollider
        GetComponent<BoxCollider2D>().isTrigger = true;
    }
    //Every interactable will have a different function
    public abstract void Interact();

    //How close the player needs to be to pick
    //up or interact with objects
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.tag == "InteractionObject")
        {
            if (collision.CompareTag("Player"))
            {
                //collision.GetComponent<PlayerController>().OpenInteractableIcon();
            }
        }
    }

    //opening and closing interact message
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //collision.GetComponent<PlayerController>().CloseInteractableIcon();

        }
    }
}
