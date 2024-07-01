using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public List<GameObject> spawnPoints;
    public List<GameObject> spawnItems;
    public int amtToSpawn;
    private int _spawnPointAmt;
    
//TODO: make prefabs out of SpawnItems
    void Start()
    {
        SelectSpawnPoints();
        SpawnItems();
    }

    public void SelectSpawnPoints()
    {
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

    public void SpawnItems()
    {
        UpdateSpawnAmt();
        for (int i = 0; i < _spawnPointAmt; i++)
        {
            
            int a = Random.Range(0, spawnItems.Count);
            var f=Instantiate(spawnItems[a], spawnPoints[i].transform.position,spawnPoints[i].transform.rotation );
            f.SetActive(true);
            f.transform.parent = spawnPoints[i].transform;
            
        }
    }

    public void UpdateSpawnAmt()
    {
        _spawnPointAmt = spawnPoints.Count;
    }
}
