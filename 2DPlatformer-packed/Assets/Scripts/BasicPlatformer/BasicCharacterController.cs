using UnityEngine;
using System.Collections;

//--------------------------------------------
/*Basic Character Controller Includes:  
    - Basic Jumping
    - Basic grounding with line traces
    - Basic horizontal movement
 */
//--------------------------------------------

public class BasicCharacterController : MonoBehaviour
{
    protected bool facingRight = true;
    protected bool jumped;

    public float speed = 5.0f;
    public float jumpForce = 16f;
    public float currenthealth;

    private float horizInput;

    public Transform groundedCheckStart;
    public Transform groundedCheckEnd;
    public bool grounded;

    public Transform respawnPoint;

    public Rigidbody2D rb;

    protected Animator anim;

    void Awake()
    {
        
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }



    void FixedUpdate()
    {
        //Linecast to our groundcheck gameobject if we hit a layer called "Level" then we're grounded
        grounded = Physics2D.Linecast(groundedCheckStart.position, groundedCheckEnd.position, 1 << LayerMask.NameToLayer("Level"));
        Debug.DrawLine(groundedCheckStart.position, groundedCheckEnd.position, Color.red);


        //rb.velocity = new Vector2(horizInput * speed * Time.fixedDeltaTime, rb.velocity.y);

        //Move Character
        //if (grounded && rb.velocity!)
        if (transform.parent != null && transform.parent.tag == "Moving Platform")
        {
        //If they're parented (on the platform)

        //Debug.Log("parented");

            if(horizInput != 0)
            {
                Debug.Log(horizInput);
                rb.velocity = new Vector2(horizInput * speed * Time.fixedDeltaTime, rb.velocity.y);
            //rb.AddForce(new Vector2(horizInput * speed * Time.fixedDeltaTime, rb.velocity.y) * 2, ForceMode2D.Force);
            }
                    
        }
        else
        {
            rb.velocity = new Vector2(horizInput * speed * Time.fixedDeltaTime, rb.velocity.y);
        }




        // Detect if character sprite needs flipping
        if (horizInput > 0 && !facingRight)
        {
            FlipSprite();
        }
        else if (horizInput < 0 && facingRight)
        {
            FlipSprite();
        }



    }

    void Update()
    {
        Animation();


        if (Input.GetButtonDown("Jump") && grounded == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0.0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        //Get Player input 
        horizInput = Input.GetAxis("Horizontal");

        currenthealth = GetComponent<Health>().health;

        if (currenthealth <= 0)
        {
            transform.position = respawnPoint.position;
            gameObject.GetComponent<Health>().getHealth(100);
            gameObject.GetComponent<Score>().removeAllCoins();
        }


    }


    // Flip Character Sprite
    void FlipSprite()
    {
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }

    void Animation()
    {
        anim.SetFloat("animspeed", Mathf.Abs(horizInput));

        if (!grounded)
        {
            anim.SetBool("animjump", true);
        }

        if (grounded)
        {
            anim.SetBool("animjump", false);
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("1");
        if (other.gameObject.tag == "Enemy")
        {
            if (gameObject.GetComponent<Health>() != null)
            {
                gameObject.GetComponent<Health>().takeDamage(20);
            }
        }

    }

    //void OnColliderEnter2D(Collider2D other)
    //{



    //}



}