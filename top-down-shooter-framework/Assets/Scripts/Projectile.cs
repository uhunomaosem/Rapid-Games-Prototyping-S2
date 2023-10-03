using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public Vector2 direction;
    public float speed = 5.0f;

    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = direction * speed;

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<Health>().takeDamage(1);
        }

        Destroy(gameObject);

    }
}
