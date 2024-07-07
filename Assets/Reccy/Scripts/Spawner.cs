using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> spawnPoints;

    public GameObject moneyPrefab;
    public GameObject goldBarPrefab;

    private List<GameObject> spawnedItems = new List<GameObject>();

    public void SpawnItems(float scoreLimit)
    {
        List<GameObject> spawnables = getCollectibles(scoreLimit);

        List<int> spawnPointIndeces = SelectSpawnPoints(spawnables.Count).ToList();
        spawnedItems.Clear();
        
        for (int i = 0; i < spawnables.Count; i++)
        {
            if (i >= spawnPoints.Count)
                break;

            int spawnPointIndex = spawnPointIndeces[i];
            GameObject newObject = Instantiate(spawnables[i]);
            newObject.transform.position = spawnPoints[spawnPointIndex].transform.position;
            newObject.transform.parent = spawnPoints[spawnPointIndex].transform;
            spawnedItems.Add(newObject);
        }
    }

    private List<GameObject> getCollectibles(float scoreLimit)
    {
        if (scoreLimit == 300)   // long game
        {
            List<GameObject> ret = new List<GameObject>();
            for (int i = 0; i < 5; i++) {
                ret.Add(moneyPrefab);
            }
            for (int i = 0; i < 2; i++)
            {
                ret.Add(goldBarPrefab);
            }
            return ret;
        }
        else if(scoreLimit == 200)  // short game
        {
            List<GameObject> ret = new List<GameObject>();
            for (int i = 0; i < 5; i++)
            {
                ret.Add(moneyPrefab);
            }
            for (int i = 0; i < 1; i++)
            {
                ret.Add(goldBarPrefab);
            }
            return ret;
        }
        return new List<GameObject>();
    }

    private HashSet<int> SelectSpawnPoints(int count)
    {
        HashSet<int> selectedIndeces = new HashSet<int>();
        for (int i = 0; i < count; i++)
        {
            while (!selectedIndeces.Add(Random.Range(0, spawnPoints.Count - 1)));
        }
        return selectedIndeces;
    }
}