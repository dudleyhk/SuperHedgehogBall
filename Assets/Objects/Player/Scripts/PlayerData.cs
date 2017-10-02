﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{

    int lives = 3;
    private static int score;
    int collectedBananas = 0;
    float speed = 0;

    private GameObject player;
    private Rigidbody2D rigidBody;

    private void Start()
    {
        player = gameObject;
        rigidBody = player.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        /**
          * Calculation of speed from velocity goes here
          **/
        speed = rigidBody.velocity.magnitude;
    }

    public int getLives()
    {
        return lives;
    }

    public int getBananas()
    {
        return collectedBananas;
    }

    public static int Score
    {
        get
        {
            return score;
        }
    }

    public float getSpeed()
    {
        return speed;
    }
    
    public void modifyLives(int amount)
    {
        lives += amount;
    }

    public void modifyScore(int amount)
    {
        score += amount;
    }

    public void modifyBananas(int amount)
    {
        score += amount;
        if (score >= 100)
        {
            if (getLives() < 3)
            {
                modifyLives(1);
            }
        }
    }
}
