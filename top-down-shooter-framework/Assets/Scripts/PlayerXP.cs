using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerXP : MonoBehaviour
{
    private int exp;
    private int currentLevel;
    void AddExp(int expToAdd)
    {
        this.exp += expToAdd;
        int expToNextLevel = (this.currentLevel * 5);
        if (exp >= expToNextLevel) 
        {
            this.currentLevel += 1;
            this.exp = 0;
            Debug.Log("Level" + this.currentLevel);
        }
    }
}
