using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeLEvel : MonoBehaviour
{

    public LevelSetup setter;
    public Spawner spawner;

    public void init()
    {
       spawner.SetSpawnedItems(setter.ItemsToSpawn);
       spawner.SpawnItems();
    }
}
