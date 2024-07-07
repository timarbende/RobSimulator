using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValueDetector : MonoBehaviour
{
    private bool IsEquipped;
    public float radius;
    private List<GameObject> _valueItems;
    public Spawner spawner;

    private Material mat;
    public Color EmissionColor;

    private void Start()
    {
        _valueItems = new List<GameObject>();
        /*foreach (var spawn in spawner.spawnedItems)
        {
            _valueItems.Add(spawn);
        }*/

        mat = gameObject.transform.GetChild(0).gameObject.GetComponent<Renderer>().material;
     //   Equip(true);
    }

    [ContextMenu("a")]
    public void e()
    {
        Equip(true);
    }
    public void Equip(bool equip)
    {
        IsEquipped = equip;
        if (IsEquipped)
        {
            StopCoroutine(RunDevice());
            StartCoroutine(RunDevice());
        }
    }

    IEnumerator RunDevice()
    {
        while (IsEquipped)
        {
            checkForValuables();
            yield return new WaitForSeconds(0.1f);
        }

        yield return null;
    }

    public void checkForValuables()
    {
        foreach (GameObject valueItem in _valueItems)
        {
            if (!valueItem.activeSelf) continue;
            else
            {
                Vector3 a = gameObject.transform.position - valueItem.transform.position;
                if (a.magnitude < radius) {
                    print("a.mag : " +a.magnitude+" "+radius);
                    SetLamp(true);
                    return;
                }
            }
            
        }
        SetLamp(false);
    }

   
    public void SetLamp(bool senses)
    {
        if (senses)
        {
            mat.SetColor("_EmissionColor",EmissionColor);
            mat.SetColor("_Color", EmissionColor);
        }
        else
        {
            mat.SetColor("_EmissionColor",Color.black);
            mat.SetColor("_Color", Color.white);
        }
       // mat.EnableKeyword("_EMISSION");
    }
}