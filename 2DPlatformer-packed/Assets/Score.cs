using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public static int score = 0;
    public Text scoreText;



    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = score.ToString();
    }

    public void AddCoins(int score)
    {
        score += score;
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
