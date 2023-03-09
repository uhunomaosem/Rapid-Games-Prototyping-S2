using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPlat : MonoBehaviour
{
    public LayerMask collisionMask;

    public Transform pointOne;
    public Transform pointTwo;

    public float moveTime = 1;
    private float moveSpeed;
    private Vector2 maximumDistance;

    private Rigidbody2D rb;
    private Transform moveToPoint;

    // Start is called before the first frame update
    void Start()
    {
     if (moveTime == 0.0f)
        {
            moveTime = 10;
        }
        rb = GetComponent<Rigidbody2D>();
        moveToPoint = pointTwo;
        moveSpeed = Vector3.Distance(pointOne.position, pointTwo.position) / moveTime;
        Debug.Log(moveSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 distanceRemaining = moveToPoint.position - transform.position;
        maximumDistance = distanceRemaining.normalized * moveSpeed * Time.fixedDeltaTime;

        if (maximumDistance.magnitude >= distanceRemaining.magnitude || distanceRemaining.magnitude == 0)
        {
            maximumDistance = distanceRemaining;

            Debug.Log("Swapping Destination");

            //swap points

            if (moveToPoint == pointOne)
            {
                moveToPoint = pointTwo;
            }
            else
            {
                moveToPoint = pointOne;
            }
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition((Vector2)transform.position + maximumDistance);
        //transform.Translate(Vector2.left * Time.deltaTime);
       
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collisionMask == (collisionMask | (1 << collision.gameObject.layer)))
        {
            collision.collider.transform.SetParent(transform);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collisionMask == (collisionMask | (1 << collision.gameObject.layer)))
        {
            collision.collider.transform.SetParent(null);
        }
    }

}
