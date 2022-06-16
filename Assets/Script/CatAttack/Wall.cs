using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public float life = 100f;
    public float lifeMax = 100f;
	private Rigidbody2D rb;

	public GameObject wall;

	public GameObject turret;

	public bool isInvincible = false;
	private bool isHitted = false;

	// Update is called once per frame
	void Update()
    {
        if (life <= 0)
        {
			AkSoundEngine.PostEvent("wall_destroy", wall); //must include specfic name of event
			wall.SetActive(false);
			turret.SetActive(false);
		}
    }

	public void ApplyDamage(float damage)
	{
		if (!isInvincible)
		{
			float direction = damage / Mathf.Abs(damage);
			damage = Mathf.Abs(damage);
			life -= damage;
			
		}
	}

	
}
