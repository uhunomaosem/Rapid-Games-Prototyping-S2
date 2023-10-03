using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Health : MonoBehaviour
{
    public static Action onPlayerDeath;

    public float health;
    const float maxHealth = 3;
    public Image healthBar;
    public bool hasHealthBar;


    public GameObject WinMenu;
    public GameObject HealthBarOBJ;
    public GameObject player;

    bool finished = false;
    private float finalscore;
    private int finaltime;
    public TMP_Text FinalSeconds;
    public TMP_Text FinalEnemiesKilled;
    private float totalScore;



    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (hasHealthBar)
        {
            healthBar.fillAmount = health / 3;
        }
    }

    public void takeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            if (gameObject != null)
            {
                health = 0;
                if (tag == "Player")
                {
                    finished = true;
                    if (finished)
                    {

                        WinMenu.SetActive(true);
                        finished = true;
                        Time.timeScale = 0f;
                        finalscore = gameObject.GetComponent<Score>().kills;
                        finaltime = gameObject.GetComponent<Timer>().seconds;
                        Destroy(GameObject.Find("PlayerCanvas"));
                        FinalSeconds.text = "Time Taken: " + finaltime.ToString("N0");
                        FinalEnemiesKilled.text = "Enemies Killed: " + finalscore.ToString("N0");

                    }
                }
                if (tag == "Enemy")
                {
                    if (GetComponent<Health>().health <= 0)
                    {
                        Debug.Log("+1");
                        player.GetComponent<Score>().AddScore(1);
                    }
                    Destroy(gameObject);

                }
            }

        }
    }


}
