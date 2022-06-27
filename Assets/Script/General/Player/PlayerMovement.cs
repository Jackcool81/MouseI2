using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public CharacterController2D controller;
	public Animator animator;

	public float runSpeed = 40f;
	public GameObject player;
	private Vector2 boxSize = new Vector2(0.1f, 1f);


	public float horizontalMove = 0f;
	bool jump = false;
	bool dash = false;

	public GameObject questLog; 

	//bool dashAxis = false;
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.E))
        {
            CheckInteraction();
        }

		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
		
		animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

		if (Input.GetKeyDown(KeyCode.W))
		{
			jump = true;
		}

		if (Input.GetKeyDown(KeyCode.LeftShift))
		{
			dash = true;
		}
		if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (questLog.activeSelf == false)
            {
                questLog.SetActive(true);
            }
            else
            {
                questLog.SetActive(false);
            }
//Spep
        }

	}

	public void OnFall()
	{
		animator.SetBool("IsJumping", true);
	}

	public void OnLanding()
	{
		animator.SetBool("IsJumping", false);
	}

	void FixedUpdate ()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, jump, dash);
		jump = false;
		dash = false;
	}

	private void CheckInteraction()
    {
		
        //using ray casting with box? using array
        RaycastHit2D[] hits = Physics2D.BoxCastAll(transform.position, boxSize, 0, Vector2.zero);
        if (hits.Length > 0)
        {
            //Line to see if there is something that collides with it 
            //Hit scan
            foreach(RaycastHit2D rc in hits)
            {
                
                if (rc.transform.GetComponent<Interactable>())
                {
                    rc.transform.GetComponent<Interactable>().Interact();
                    return;
                }
            }


        }

    }
}
