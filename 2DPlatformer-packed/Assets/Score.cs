using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{

    public int score = 0;
    public TMP_Text scoreText;



    public void AddCoins(int scoretoAdd)
    {
        score += scoretoAdd;
        scoreText.text = "Score: " + score;
    }



    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Coin")
        {
            Debug.Log("touching");
            AddCoins(1);
        }
    }
}
