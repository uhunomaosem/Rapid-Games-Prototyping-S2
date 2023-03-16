using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillVolume : MonoBehaviour
{
    public Transform respawnPoint;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.transform.position = respawnPoint.position;
            collision.gameObject.GetComponent<Health>().getHealth(100);
            collision.gameObject.GetComponent<Score>().removeCoins(1);
        }
    }
}
