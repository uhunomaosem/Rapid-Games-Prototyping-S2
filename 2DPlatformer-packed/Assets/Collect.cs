using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Collect : MonoBehaviour
{

    public Score Collectablescore;

    private void Start()
    {
        Collectablescore = FindObjectOfType<Score>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("touch");
            Destroy(this.gameObject);
        }
    }
}
