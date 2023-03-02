using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobScript : MonoBehaviour
{
    public bool facingRight;
    public bool jump;

    public float maxSpeed = 2.0f;
    public float maxForce = 365.0f;
    public float horizInput = 1.0f;

    protected SpriteRenderer spriteRenderer;
    protected Animator animationController;
    protected Rigidbody2D rb;

    protected BoxCollider2D floorTrigger;
    protected CapsuleCollider2D characterCollider;

    // Start is called before the first frame update
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();

        floorTrigger = GetComponent<BoxCollider2D>();

        characterCollider = GetComponent<CapsuleCollider2D>();

        if (facingRight == false)
        {
            Flip();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Level"))
        {
            Flip();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Mathf.Abs(horizInput * (rb.velocity.x)) < maxSpeed)
        {
            rb.AddForce(horizInput * Vector2.right * maxForce);
        }
        
        if (Mathf.Abs(rb.velocity.x) > maxSpeed)
        {
            rb.velocity = new Vector2(Mathf.Sign(rb.velocity.x) * maxSpeed, rb.velocity.y);
        }
    }

    void Flip()
    {
        transform.Rotate(0, 180, 0);
        horizInput *= -1;
    }
}
