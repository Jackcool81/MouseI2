using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretLucas : MonoBehaviour
{
    public float baseFireDelay = 1.0f;
    public Transform firePoint;
    public GameObject turret_barrel;
    public GameObject bullet;
    private float nextFire;
    private void FixedUpdate()
    {
        Vector3 enemyPos = FindClosestPlayer();

        if (enemyPos != transform.position)
        {
            Vector3 difference = FindClosestPlayer() - transform.position;

            difference.Normalize();

            float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(0f, 0f, rotationZ + 180);

            if (Time.time > nextFire)
            {
                Fire();
            }

            //Change y scale so the turret doesn't go upside down
            if (FindClosestPlayer().x > transform.position.x)
            {
                Vector3 theScale = transform.localScale;
                theScale.y = -1;
                transform.localScale = theScale;
            }
            else
            {
                Vector3 theScale = transform.localScale;
                theScale.y = 1;
                transform.localScale = theScale;
            }
        }



    }

    private Vector3 FindClosestPlayer()
    {
        GameObject closestPc = null;
        float minDistance = 10f;
        GameObject[] playerChars = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject pc in playerChars)
        {
            float distance = Vector2.Distance(pc.transform.position, transform.position);

            if (distance <= minDistance)
            {
                minDistance = distance;
                closestPc = pc;
            }
        }

        if (closestPc != null)
        {
            return closestPc.transform.position;
        }
        else
        {
            return this.transform.position;
        }

    }

    private void Fire()
    {
        Instantiate(bullet, firePoint.position, Quaternion.identity);
        nextFire = Time.time + baseFireDelay;
        AkSoundEngine.PostEvent("turret_fire", turret_barrel); //must include specfic name of even

    }
}
