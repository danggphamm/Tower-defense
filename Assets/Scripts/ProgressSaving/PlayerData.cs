using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// Class that contains the player data
[Serializable]
public class PlayerData
{
    // The high score
    public int _currentHighLevel;

    // Constructor
    public PlayerData(int currentHighLevel)
    {
        _currentHighLevel = currentHighLevel;
    }

    // Set highScore
    public void SetHighScore(int currentHighLevel)
    {
        _currentHighLevel = currentHighLevel;
    }
}