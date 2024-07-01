using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Collectible : MonoBehaviour
{
    // Start is called before the first frame update
    public float score;
    private UnityEvent AddToScore;

    void Start()
    {
        AddToScore = new UnityEvent();
        AddToScore.AddListener(delegate { GameInfo.Instance.UpdateScore(score); });
    }


    [ContextMenu("collect")]
    public void Collect()
    {
        AddToScore.Invoke();
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }
}