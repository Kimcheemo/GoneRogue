using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    int playerLives;
    int playerRounds;

    int currentLevel;

    void Start()
    {
        playerRounds = 0;
        playerLives = 3;
        currentLevel = 1;
        PlayerPrefs.SetInt("Lives", playerLives);
        PlayerPrefs.SetInt("Rounds", playerRounds);
        PlayerPrefs.SetInt("CurrentLevel", currentLevel);
    }
}
