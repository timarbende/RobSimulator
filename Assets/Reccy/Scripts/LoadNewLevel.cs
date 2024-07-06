using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNewLevel : MonoBehaviour
{
    public LevelSetup lev;
    public LevelDiffSelector ldiff;
    public GameObject g;
    [ContextMenu("push")]
    public void OnPush()
    {
        lev.ItemsToSpawn.Clear();
        foreach (var ob in ldiff.objects)
        {
            lev.ItemsToSpawn.Add(ob.name);  
        }

        SceneManager.LoadScene(lev.Level);
    }
}