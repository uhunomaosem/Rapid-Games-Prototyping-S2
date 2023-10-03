using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class Score : MonoBehaviour
{
    public TMP_Text Kills;
    public int kills = 0;

    public void AddScore(int KillstoAdd)
    {
        kills += KillstoAdd;
        Kills.text = "Enemies Killed: " + kills;
    }


}
