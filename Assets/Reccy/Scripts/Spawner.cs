using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> spawnPoints;
    public int amtToSpawn;
    private int _spawnPointAmt;
    
    public List<GameObject> spawnedItems;

    public GameObject moneyPrefab;
    public GameObject diamondPrefab;

    public void SelectSpawnPoints()
    {
        //get random spawn points
        _spawnPointAmt = spawnPoints.Count;
        if (amtToSpawn > _spawnPointAmt)
        {
            amtToSpawn = _spawnPointAmt;
            return;
        }

        int toRemove = _spawnPointAmt - amtToSpawn;
        for (int i = 0; i < toRemove; i++)
        {
            int a = Random.Range(0, _spawnPointAmt);
            spawnPoints.RemoveAt(a);
            _spawnPointAmt--;
        }
    }

    public void SpawnItems(float scoreLimit)
    {
        SelectSpawnPoints();
        spawnedItems.Clear();
        UpdateSpawnAmt();

        List<GameObject> spawnables = getCollectibles(scoreLimit);
        for (int i = 0; i < spawnables.Count; i++)
        {
            if (i >= spawnPoints.Count)
                break;

            GameObject newObject = Instantiate(spawnables[i]);
            newObject.transform.position = spawnPoints[i].transform.position;
            newObject.transform.parent = spawnPoints[i].transform;
            spawnedItems.Add(newObject);
        }
    }

    private List<GameObject> getCollectibles(float scoreLimit)
    {
        if (scoreLimit == 300)   // long game
        {
            List<GameObject> ret = new List<GameObject>();
            for (int i = 0; i < 10; i++) {
                ret.Add(moneyPrefab);
            }
            for (int i = 0; i < 2; i++)
            {
                ret.Add(diamondPrefab);
            }
            return ret;
        }
        else if(scoreLimit == 200)  // short game
        {
            List<GameObject> ret = new List<GameObject>();
            for (int i = 0; i < 10; i++)
            {
                ret.Add(moneyPrefab);
            }
            for (int i = 0; i < 1; i++)
            {
                ret.Add(diamondPrefab);
            }
            return ret;
        }
        return new List<GameObject>();
    }

    /*public void SetSpawnedItems(List<string> a)
    {
        spawnItems = new List<string>();
        spawnedItems.Clear();
        spawnItems.Clear();
        foreach (var b in a)
        {
            var name = b.Split(' ', 2);
            spawnItems.Add(name[0]);
        }

    }*/

    public void UpdateSpawnAmt()
    {
        _spawnPointAmt = spawnPoints.Count;
    }
}