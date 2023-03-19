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

    private float horizInput;

    public Transform groundedCheckStart;
    public Transform groundedCheckEnd;
    public bool grounded;



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


        rb.velocity = new Vector2(horizInput * speed * Time.fixedDeltaTime, rb.velocity.y);

        //Move Character
        //if(grounded && rb.velocity !)
        //if (transform.parent != null && transform.parent.tag == "Moving Platform")
        //{
        //    //If they're parented (on the platform)
        //    rb.AddForce(new Vector2(horizInput * speed * Time.fixedDeltaTime, rb.velocity.y) *2 , ForceMode2D.Force);
        //}
        //else
        //{
        //    rb.velocity = new Vector2(horizInput * speed * Time.fixedDeltaTime, rb.velocity.y);
        //}

        //else if(Input.GetButtonUp("Jump"))
        //{
        //    jumped = false;
        //}

        //if (Input.GetButtonDown("Jump") && grounded == true)
        //{
        //    jumped = true;
        //    Debug.Log("Should jump");
        //}

        //if (jumped == true)
        //{
        //    rb.AddForce(new Vector2(0f, jumpForce));
        //    Debug.Log("Jumping!");

        //    jumped = false;
        //}


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


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            if (gameObject.GetComponent<Health>() != null)
            {
                gameObject.GetComponent<Health>().takeDamage(20);
            }


        }



    }


  

}