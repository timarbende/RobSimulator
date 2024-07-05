using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowInText : MonoBehaviour
{
    public TextMeshPro text;

    private void Awake()
    {
        text = this.GetComponent<TextMeshPro>();
    }

    public void ShowScoreInText(float score)
    {
        text.text = "Goal: " + score;
    }

    public void ShowLevel(int lvl)
    {
        if (lvl > 0)
        {
            text.text = "Level: " + lvl;
        }
        else
        {
            text.text = "No Level Selected";
        }
    }
}