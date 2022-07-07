using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HatchInteractable : Interactable
{
   public string Inside = "ShipHub";    //This is so we can update the name of the scene as needed, up here
   public string Outside = "CatAttack";

   public bool interacted1 = false;
    //public GameObject car;
   // public GameObject player;
  //  public GameObject camera;
   public override void Interact()
   {
      Scene currentScene = SceneManager.GetActiveScene();
      if (currentScene.name == Inside)
      {
         TeleportOut();
      }
      else if (currentScene.name == Outside)
      {
         TeleportIn();
      }
      else
      {
         print("error found in HatchInteractable.cs relating to the Interact()");
      }

      print("Type code in here");
   }
   public void TeleportIn()
   {
      SceneManager.LoadScene(Inside);
   }
   public void TeleportOut()
   {
      SceneManager.LoadScene(Outside);
   }

   void Update()
   {
      
   }

   

}