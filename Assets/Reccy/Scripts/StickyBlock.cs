using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class StickyBlock : MonoBehaviour
{
    public GameObject instantiatedSticky;
    public GameObject spawner;

    void Start()
    {
        respawnItem();
    }

    public void OnStickyTaken()
    {
        respawnItem();
    }

    public void respawnItem()
    {
        GameObject newSticky = Instantiate(instantiatedSticky, spawner.transform);
        newSticky.SetActive(true);
        StickyNote stick = newSticky.GetComponent<StickyNote>();
        stick.Respawner(this);
    }
}
