using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SelectLevel : MonoBehaviour
{
    public LevelSetup lev;
    public ShowInText show;
    public UnityEvent<int> levelEvent;
    void Start()
    {
        levelEvent = new UnityEvent<int>();
        levelEvent.AddListener(lev.SetLevel);
        levelEvent.AddListener(show.ShowLevel);
        levelEvent.Invoke(-1);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("sticky"))
        {
            Level leve = other.gameObject.GetComponent<Level>();
            levelEvent.Invoke(leve.number);
            leve.InstantiateCollectibles();
            
            
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("sticky"))
        {
            Level leve = other.gameObject.GetComponent<Level>();
            leve.ClearSpawner();
            levelEvent.Invoke(-1);
        }
    }
}
