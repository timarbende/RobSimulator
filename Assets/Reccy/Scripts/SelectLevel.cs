using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class SelectLevel : MonoBehaviour
{
    public LevelSetup lev;
    public ShowInText show;
    public UnityEvent<int> levelEvent;
    public float radius = 2f;
    private bool hasLevel;
    private int levelCard;
    public List<GameObject> fucks;
    void Start()
    {
        levelEvent = new UnityEvent<int>();
        levelEvent.AddListener(lev.SetLevel);
        levelEvent.AddListener(show.ShowLevel);
        levelEvent.Invoke(-1);

    }

    public void evalDistance()
    {
        int counter = 0;
        
        for (int i = 0; i < fucks.Count; i++)
        {
            var r = fucks[i].transform.position - this.transform.position;
            var g = r.magnitude;
            if (g < radius) counter++;
            if (g < radius&&!hasLevel)
            {
                            
                Level leve = fucks[i].gameObject.GetComponent<Level>();
                levelEvent.Invoke(leve.number);
                levelCard=i;
                hasLevel = true;
                leve.InstantiateCollectibles();
                return;
                            
            }
            
        }

        if (hasLevel&& counter==fucks.Count)
        {
              fucks[levelCard].GetComponent<Level>().ClearSpawner();
              levelEvent.Invoke(-1);
        }
      
    }

    private void Update()
    {
        evalDistance();
    }

 /*   private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("sticky"))
        {
        
            
            
        }
    }*/
    
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
