using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform Target;

    public float Range;
    public float FireRate = 1f;
    private float FireCountdown = 0f;

   
    public Transform PathToRotate;

    public string enemyTag = "Enemy";

    bool Detected = false;

    Vector2 Direction;

    public GameObject Gun;

    public GameObject Bullet;



    public GameObject AlarmLight;

    public float nextTimeToFire = 0;

    public Transform ShootPoint;

    public float Force;
   
    void Start ()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    // Update is called once per frame
    void UpdateTarget()
    {
        
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        //nearestEnemy check its life instead of null
        if (nearestEnemy.GetComponent<Enemy>().life > 0 && shortestDistance <= Range)
        {
            Target = nearestEnemy.transform;
        }
        else
        {
            Target = null;
        }



        

    }
    void Update()
    {
       if (Target == null)
        {
            AlarmLight.GetComponent<SpriteRenderer>().color = Color.green;
            return;
        }
       // float rotationAngle = Vector2.SignedAngle(Vector2.left, Target.position - transform.position);
      //  transform.Rotate(Vector3.forward, rotationAngle);
        AlarmLight.GetComponent<SpriteRenderer>().color = Color.red;
        Direction = Target.position - transform.position;
        
        //Direction.Normalize();
        float rotationZ = Mathf.Atan2(Direction.y, Direction.x) * Mathf.Rad2Deg;
        //`Debug.Log(Direction[1]);
        if (rotationZ < -75 || rotationZ > -3)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);
           //ShootPoint.rotation = Quaternion.Euler(0f, 0f, rotationZ);

            if (FireCountdown <= 0f)
            {
                float rotationAngle = Vector2.SignedAngle(Vector2.left, Target.position - transform.position);
                transform.Rotate(Vector3.forward, rotationAngle);
                //ShootPoint.Rotate(Vector3.forward, rotationAngle);
                shoot(ShootPoint.position);
                FireCountdown = 1f / FireRate;
            }

            FireCountdown -= Time.deltaTime;
        }
        
        
        if (rotationZ < -90 || rotationZ > 90)
        {



            if (transform.eulerAngles.y == 0)
            {


                transform.localRotation = Quaternion.Euler(180, 0, -rotationZ);


            }
            else if (transform.eulerAngles.y == 180)
            {


                transform.localRotation = Quaternion.Euler(180, 180, -rotationZ);


            }
        
        }
        
        //Vector3 dir = Target.position - transform.position;
        //Quaternion lookRotation = Quaternion.LookRotation(dir);
        //Vector3 rotation = lookRotation.eulerAngles;
        //PathToRotate.rotation = Quaternion.Euler(0f, rotation.z, 0f);
        /*
         Vector2 targetPos = Target.position;

         Direction = targetPos - (Vector2)transform.position;

         RaycastHit2D rayInfo = Physics2D.Raycast(transform.position, Direction, Range);

         if (rayInfo)
         {
             if(rayInfo.collider.gameObject.tag == "Enemy")
             {

                     if (Detected == false)
                     {
                         Detected = true;
                         AlarmLight.GetComponent<SpriteRenderer>().color = Color.red;
                         Debug.Log("I SEE YOU");
                     }
             }
             else
             {
                     if (Detected == true)
                     {
                         Detected = false;
                         Debug.Log("I NO SEE YOU");
                         AlarmLight.GetComponent<SpriteRenderer>().color = Color.green;

                     }

             }
         }
     */
        // if (Detected)
        // 
        //Gun.transform.up = Direction;
        
      //  }
       
    }

    void shoot(Vector3 ShootPo)
    {
        if (Target.GetComponent<Enemy>().life > 0)
        {
            GameObject BulletIns = Instantiate(Bullet, ShootPo, Quaternion.identity);
            Debug.Log("THIS IS BULLET SPAWN POS" + BulletIns.transform.position);
            //Debug.Log("THIS IS WHERE IT SHOULD SPAWN", ShootPo);
            BulletIns.GetComponent<Rigidbody2D>().AddForce(Direction * Force);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, Range);
    }
}
