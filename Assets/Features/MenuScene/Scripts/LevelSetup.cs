using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelSetup", menuName = "ScriptableObjects/LevelSetup", order = 1)]
public class LevelSetup : ScriptableObject
{
    public int Level;
    public float ScoreLimit;

    public void SetScoreLimit(float scoreLimit)
    {
        ScoreLimit = scoreLimit;
    }

    public void SetLevel(int lev = 1)
    {
        Level = lev;
    }
}
