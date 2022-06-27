using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
	public float dmgValue = 4;
	public GameObject throwableObject;
	public GameObject player;
	public Transform attackCheck;
	private Rigidbody2D m_Rigidbody2D;
	public Animator animator;
	public bool canAttack = true;
	public bool isTimeToCheck = false;
	[HideInInspector]
	public bool fire = false;

	public GameObject cam;

	int ProjectileSpeed = 10;
	float FireRate = 10f;  // The number of bullets fired per second
	float lastfired;

	private void Awake()
	{
		m_Rigidbody2D = GetComponent<Rigidbody2D>();
	}

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

		if (Input.GetKey(KeyCode.Space))
        {
			animator.SetBool("IsAttacking", true);	
			
			if (Time.time - lastfired > 1 / FireRate)
			{
				lastfired = Time.time;
				GameObject throwableWeapon = Instantiate(throwableObject, transform.position + new Vector3(transform.localScale.x * 0.5f, 0f), Quaternion.identity) as GameObject;
				Vector2 direction = new Vector2(transform.localScale.x, 0);
				throwableWeapon.GetComponent<ThrowableWeapon>().direction = direction;
				//throwableWeapon.name = "ThrowableWeapon";
				cam.GetComponent<CameraFollow>().ShakeCamera();
				// AkSoundEngine.PostEvent("pc_fire", player); //must include specfic name of even
			}
		}
		else
		{animator.SetBool("IsAttacking", false);}
		
	}

	/*
	 * 
	 * lastfired = Time.time;
				GameObject clone;
				clone = Instantiate(throwableObject, transform.position + new Vector3(transform.localScale.x * 0.5f, 0f), Quaternion.identity);// as GameObject;
				clone.GetComponent<RigidBody2D>().velocity = transform.TransformDirection(Vector3.forward * ProjectileSpeed);
				//Vector2 direction = new Vector2(transform.localScale.x, 0);
				//throwableWeapon.GetComponent<ThrowableWeapon>().direction = direction;
				//throwableWeapon.name = "ThrowableWeapon";
	*/

	IEnumerator AttackCooldown()
	{
		yield return new WaitForSeconds(2f);
		canAttack = true;
	}

	public void DoDashDamage()
	{
		dmgValue = Mathf.Abs(dmgValue);
		Collider2D[] collidersEnemies = Physics2D.OverlapCircleAll(attackCheck.position, 0.9f);
		for (int i = 0; i < collidersEnemies.Length; i++)
		{
			if (collidersEnemies[i].gameObject.tag == "Enemy")
			{
				if (collidersEnemies[i].transform.position.x - transform.position.x < 0)
				{
					dmgValue = -dmgValue;
				}
				collidersEnemies[i].gameObject.SendMessage("ApplyDamage", dmgValue);
				cam.GetComponent<CameraFollow>().ShakeCamera();
			}
		}
	}
}
