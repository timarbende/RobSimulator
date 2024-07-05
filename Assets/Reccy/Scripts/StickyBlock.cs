using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class StickyBlock : MonoBehaviour
{
    public GameObject instantiatedSticky;
    public GameObject spawner;
    private bool HasInstantiated;
    
    void Start()
    {
      respawnItem();
    }


    void Update()
    {
        
    }

    public void respawnItem()
    {
        if (spawner.transform.childCount>0) HasInstantiated = true;
        else
        {
            HasInstantiated = false;
        }
        
        if(!HasInstantiated)
        {
            GameObject a = Instantiate(instantiatedSticky, spawner.transform);
            StickyNote stick = a.GetComponent<StickyNote>();
            stick.Respawner(this);
            HasInstantiated = true;
        }
        

    }
}
