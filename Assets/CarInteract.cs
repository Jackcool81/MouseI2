using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Yarn.Unity;


//A class that changes the type of sprite
[RequireComponent(typeof(SpriteRenderer))]
public class CarInteract : Interactable
{

    public bool interacted1 = false;
    //public GameObject car;
   // public GameObject player;
  //  public GameObject camera;
    public string dialogueNode;
    private int DialougeStart = 0;




    public override void Interact()
    {
       // if (car.tag == "InteractionObject")
       // {
       // {
           // camera.GetComponent<FollowPlayer>().player = car;
           // car.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
           // player.SetActive(false);
       // }
       // if (car.tag == "InteractionObject" && DialougeStart == 0)
       // {
           // FindObjectOfType<DialogueRunner>().StartDialogue(dialogueNode);
        //    DialougeStart = 1;

       // }
    }

}
