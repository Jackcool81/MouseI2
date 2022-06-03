using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimedMovement : MonoBehaviour
{
    public float speed = 3.5f;
    public bool canAimBackwards;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
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

       

        rb = GetComponent<Rigidbody2D>();
        if (closestPc == null || (!canAimBackwards && closestPc.transform.position.x >= transform.position.x))
        {
            rb.velocity = Vector2.left * speed;
        }
        else
        {
            // In degrees
            float rotationAngle = Vector2.SignedAngle(Vector2.left, closestPc.transform.position - transform.position);
            transform.Rotate(Vector3.forward, rotationAngle);
            // Debug.Log("rotationAngle: " + rotationAngle);

            // rb.velocity = new Vector2(0, 1);
            // In radians since that's what Mathf.Cos and Mathf.Sin use
            float velocityVectorAngle = (rotationAngle + 180) * Mathf.Deg2Rad;
            Vector2 baseVelocity = new Vector2(Mathf.Cos(velocityVectorAngle), Mathf.Sin(velocityVectorAngle));
            rb.velocity = baseVelocity * speed;
            // Debug.Log("baseVelocity: " + baseVelocity);
        }

        // Debug.Log("Velocity: " + rb.velocity);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Where I would call apply damage
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<Enemy>().ApplyDamage(2f);
            Destroy(gameObject);
        }
        else if (other.gameObject.tag == "Wall")
        {
        }
        else
        {
            Destroy(gameObject);
        }

    }
}
