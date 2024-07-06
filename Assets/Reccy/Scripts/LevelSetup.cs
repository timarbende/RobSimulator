using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelSetup", menuName = "ScriptableObjects/LevelSetup", order = 1)]
public class LevelSetup : ScriptableObject
{
    public int Level;
    public float ScoreAmt;
    public List<string> ItemsToSpawn;

    public void SetScore(float score)
    {
        ScoreAmt = score;
    }

    public void SetLevel(int lev = 1)
    {
        Level = lev;
    }
}
