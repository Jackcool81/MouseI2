using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public CharacterController2D controller;
	public Animator animator;

	public float runSpeed = 40f;
	public GameObject player;

	public float horizontalMove = 0f;
	bool jump = false;
	bool dash = false;

	public GameObject questLog; 

	//bool dashAxis = false;
	
	// Update is called once per frame
	void Update () {

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
}
