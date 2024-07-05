using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelDiffSelector : MonoBehaviour
{

    public UnityEvent<float> Scorechange;
    public LevelSetup setup;
    
    public List<GameObject> objects;
    public ShowInText ScoreUI;
    public float score;

    private void Start()
    {
        Scorechange = new UnityEvent<float>();
        Scorechange.AddListener(ScoreUI.ShowScoreInText);
        Scorechange.AddListener(setup.SetScore);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("valuable"))
        {
            
            objects.Add(other.gameObject);
            Collectible col=other.gameObject.GetComponent<Collectible>();
            score += col.score;
            Scorechange.Invoke(score);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("valuable"))
        {
            FindinList(other.gameObject);
            Collectible col=other.gameObject.GetComponent<Collectible>();
            score -= col.score;
            if (score < 0) score = 0;
            Scorechange.Invoke(score);
        }
    }

    private void FindinList(GameObject obj)
    {
        foreach (var go in objects)
        {
            if (go == obj)
            {
                objects.Remove(obj);
                return;
            }
        }
    }
    
    
    
    
}
