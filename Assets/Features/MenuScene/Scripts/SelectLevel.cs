using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SocialPlatforms;

public class SelectLevel : MonoBehaviour
{
    public LevelSetup levelSetup;
    public TextMeshPro levelSelectText;
    public float radius = 0.12f;
    public string levelSelectTextDefaultText = "No level selected";

    public GameObject selectedLevel = null;

    private void Update()
    {
        sphereCast();
    }

    private void sphereCast()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, radius, 1 << 6);

        if (hits.Length > 0)
        {
            foreach (Collider hit in hits)
            {
                checkAndSetByHit(hit);
            }
        }
        else
        {
            resetSelectedLevel();
            levelSetup.SetLevel(-1);
        }
    }

    private void checkAndSetByHit(Collider other)
    {
        if(other.gameObject == selectedLevel)
        {
            return;
        }

        if (other.CompareTag("sticky"))
        {
            Level level = other.GetComponent<Level>();
            if(level == null)
            {
                return;
            }

            resetSelectedLevel();
            selectedLevel = other.gameObject;

            levelSelectText.text = level.levelName;
            levelSetup.SetLevel(level.number);
        }
    }

    private void resetSelectedLevel()
    {
        if (selectedLevel != null) { 
            selectedLevel.transform.localPosition = Vector3.zero;
            selectedLevel = null;
        }
        levelSelectText.text = levelSelectTextDefaultText;
        levelSetup.SetLevel(-1);
    }
}
