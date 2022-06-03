using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D Col)
    {
        //Destroy(this.gameObject); 
        //Where I would call apply damage
        if (Col.gameObject.tag == "Enemy")
        {
            Col.gameObject.GetComponent<Enemy>().ApplyDamage(2f);
            Destroy(gameObject);
        }
        else if (Col.gameObject.tag == "Wall")
        {
        }
        else
        {
            Destroy(gameObject);
        }

    }
}
