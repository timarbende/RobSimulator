using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public int number;

    public int maxscore;
    public List<GameObject> collects;
    public List<GameObject> InLevel;
    public GameObject spawner;

    public void InstantiateCollectibles()
    {
        foreach (var lev in InLevel)
        {
            GameObject a = Instantiate(lev, spawner.transform);
        }
        
    }

    public void ClearSpawner()
    {
        if (spawner.transform.childCount > 0)
        {
            int x = spawner.transform.childCount;
            
            for (int i = 0; i < x; i++)
            {
                GameObject a = spawner.transform.GetChild(i).gameObject;
                Destroy(a);
            }
            
            
        }
        
    }

    [ContextMenu("Initialize")]
    public void Initialize()
    {
        InLevel = new List<GameObject>();
        float score = maxscore;
        while (score > 0)
        {
            foreach (var col in collects)
            {
                var acol = col.GetComponent<Collectible>();
                InLevel.Add(col);
                score -= acol.score;
            }
        }
    }
}