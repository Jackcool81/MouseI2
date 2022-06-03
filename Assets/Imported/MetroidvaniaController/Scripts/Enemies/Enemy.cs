using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{

    public float life = 10;
    private bool isPlat;
    private bool isObstacle;
    private Transform fallCheck;
    private Transform wallCheck;
    public LayerMask turnLayerMask;
    private Rigidbody2D rb;

    private int damp = 5;

    public string playerTag = "Player";

    private float distToPlayer;
    private float distToPlayerY;

    private GameObject target;

    private bool facingRight = true;

    public float speed = 5f;

    public bool isInvincible = false;
    private bool isHitted = false;

    void Awake()
    {
        fallCheck = transform.Find("FallCheck");
        wallCheck = transform.Find("WallCheck");
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (target == null)
        {
            rb.velocity = Vector2.zero;
            Debug.Log(target);
            return;
        }
        else
        {
            if (life <= 0)
            {
                //transform.GetComponent<Animator>().SetBool("IsDead", true); ;
                int i = Random.Range(0, 3);
                if (i == 1)
                {
                    AkSoundEngine.PostEvent("cat_death1", gameObject); //must include specfic name of even
                    Debug.Log(i);

                }
                else if(i == 0)
                {
                    AkSoundEngine.PostEvent("cat_death2", gameObject); //must include specfic name of even
                    Debug.Log(i);
                }
                else if (i == 2)
                {
                    AkSoundEngine.PostEvent("cat_death3", gameObject); //must include specfic name of even
                    Debug.Log(i);
                }

                Destroy(gameObject);
                //StartCoroutine(DestroyEnemy());
            }

            distToPlayer = target.transform.position.x - transform.position.x;
            distToPlayerY = target.transform.position.y - transform.position.y;

            //transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

            isPlat = Physics2D.OverlapCircle(fallCheck.position, .2f, 1 << LayerMask.NameToLayer("Default"));
            isObstacle = Physics2D.OverlapCircle(wallCheck.position, .2f, turnLayerMask);
            if (life > 0)
            {

                rb.velocity = new Vector2(distToPlayer / Mathf.Abs(distToPlayer) * speed, rb.velocity.y);

                if (transform.position.x - 0.5 < target.transform.position.x)
                {
                    Vector3 theScale = transform.localScale;
                    theScale.x = 1;
                    transform.localScale = theScale;
                }
                else if (transform.position.x + 0.5 > target.transform.position.x)
                {
                    Vector3 theScale = transform.localScale;
                    theScale.x = -1;
                    transform.localScale = theScale;
                }


                //transform.LookAt(target);


            }
            /*
					if (!isHitted && life > 0 && Mathf.Abs(rb.velocity.y) < 0.5f)
					{
						if (isPlat && !isObstacle && !isHitted)
						{
							if (facingRight)
							{
								//transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
								//rb.velocity = new Vector2(-speed, rb.velocity.y);
								//rb.velocity = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
								rb.velocity = new Vector2(distToPlayer / Mathf.Abs(distToPlayer) * speed, rb.velocity.y);

							}
							else
							{
								//transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
								//rb.velocity = new Vector2(speed, rb.velocity.y);
								//rb.velocity = Vector2.MoveTowards(transform.position, target.position, -speed * Time.deltaTime);
								rb.velocity = new Vector2(distToPlayer / Mathf.Abs(distToPlayer) * -speed, rb.velocity.y);

							}
						}
						else
						{
							Flip();
						}
					}
					*/
        }
    }

    void Flip()
    {
        // Switch the way the player is labelled as facing.
        facingRight = !facingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public void ApplyDamage(float damage)
    {
        if (!isInvincible)
        {
            float direction = damage / Mathf.Abs(damage);
            damage = Mathf.Abs(damage);
            transform.GetComponent<Animator>().SetBool("Hit", true);
            life -= damage;
            rb.velocity = Vector2.zero;
            // rb.AddForce(new Vector2(direction * 500f, 100f));
            StartCoroutine(HitTime());
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (target == null)
        {
            Debug.Log(target);
            return;
        }
        else
        {
            if (collision.gameObject.tag == "Player" && life > 0)
            {
                collision.gameObject.GetComponent<CharacterController2D>().ApplyDamage(2f, transform.position);
            }
            if (collision.gameObject.tag == "Wall" && life > 0)
            {
                collision.gameObject.GetComponent<Wall>().ApplyDamage(2f);
            }
        }
    }

    IEnumerator HitTime()
    {
        isHitted = true;
        isInvincible = true;
        yield return new WaitForSeconds(0.1f);
        isHitted = false;
        isInvincible = false;
    }

    IEnumerator DestroyEnemy()
    {
        CapsuleCollider2D capsule = GetComponent<CapsuleCollider2D>();
        capsule.size = new Vector2(1f, 0.25f);
        capsule.offset = new Vector2(0f, -0.8f);
        capsule.direction = CapsuleDirection2D.Horizontal;
        yield return new WaitForSeconds(0.25f);
        rb.velocity = new Vector2(0, rb.velocity.y);
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}
