using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> spawnPoints;
    public List<string> spawnItems;
    public int amtToSpawn;
    private int _spawnPointAmt;
    public List<GameObject> spawnedItems;

    void Start()
    {
       // SelectSpawnPoints();
       // SpawnItems();
    }

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

    public void SpawnItems()
    {
        SelectSpawnPoints();
       spawnedItems.Clear();
        UpdateSpawnAmt();
        /*for (int i = 0; i < _spawnPointAmt; i++)
        {
            int a = Random.Range(0, spawnItems.Count);
            var f = Instantiate(spawnItems[a], spawnPoints[i].transform.position, spawnPoints[i].transform.rotation);
            //  f.SetActive(true);
            f.transform.parent = spawnPoints[i].transform;
            spawnedItems.Add(f);
        }*/

        for (int i = 0; i < spawnItems.Count; i++)
        {
               print("he");
            if (i >=spawnPoints.Count) break;
            var f =  Instantiate(Resources.Load("Prefabs/"+spawnItems[i])) as GameObject;
            f.transform.position = spawnPoints[i].transform.position;
            //  f.SetActive(true);
            f.transform.parent = spawnPoints[i].transform;
            spawnedItems.Add(f);

        }
        
    }

    public void SetSpawnedItems(List<string> a)
    {
         spawnItems = new List<string>();
         spawnedItems.Clear();
         spawnItems.Clear();
         foreach (var b in a)
         {
             var name = b.Split(' ', 2);
             spawnItems.Add(name[0]);
         }
        
    }
    
    public void UpdateSpawnAmt()
    {
        _spawnPointAmt = spawnPoints.Count;
    }
}