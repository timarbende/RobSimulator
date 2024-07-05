using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SelectLevel : MonoBehaviour
{
    public LevelSetup lev;
    public UnityEvent<int> levelEvent;
    void Start()
    {
        levelEvent = new UnityEvent<int>();
        levelEvent.AddListener(lev.SetLevel);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("sticky"))
        {
            var a = other.gameObject.transform.parent.gameObject.name;
            var f = int.Parse(a);
            levelEvent.Invoke(f);
        }
    }
}
