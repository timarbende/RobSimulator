using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameInfo : MonoBehaviour
{
    public static GameInfo Instance { get; private set; }
    public float score;
    public float winScore;
    public InitializeLEvel initializer;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

//        print("instantiated");
        initializer.init();
    }


    public void UpdateScore(float extraScore)
    {
        score += extraScore;
        print(score);
    }

    public void GameEnding()
    {
        if (score >= winScore)
        {
            //do winning thing
            print("you won");
            return;
        }
        else
        {
            //do lose thing
            print("you lost");
        }
//TODO: cutszene or something for ending condition.
    }
}