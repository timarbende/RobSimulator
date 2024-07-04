using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public delegate void OnDeselect();
public class StickyNote : MonoBehaviour
{
    public bool selected;
    private bool canProject;
    public GameObject sticky;
    private Vector3 projectPos;
    public OnDeselect respawnCall;
    private GameObject newParent;



    [ContextMenu("s")]
    public void OnSelection()
    {
        selected = true;

    }
    
    [ContextMenu("d")]
    public void OnDisSelection()
    {

        selected = false;
        //respawn new sticky
        respawnCall?.Invoke();
        Attatch();
        
    }
    

    void Update()
    {
        if (selected)
        {
            ProjectRay();
        }
    }

    public void ProjectRay()
    {
         RaycastHit hit;
                if (Physics.Raycast(transform.position, Vector3.forward, out hit, 20f))
                {
                    Vector3 vec = hit.point;
                    Vector3 a = gameObject.transform.position - hit.point;
                    newParent = hit.collider.gameObject;
                 projectPos=  vec+a*0.05f;
//                    print(vec + "name " +projectPos);
                 //   gameObject.transform.position = vec;
                    canProject = true;
                    project(projectPos);
                }
                else
                {
                    canProject = false;
                    project(Vector3.zero);
                    newParent = null;
                }
        
    }


    public void project(Vector3 vector)
    {
        if (canProject)
        {
            sticky.transform.position = vector;
            if (!sticky.activeSelf)
            {
                sticky.SetActive(true);
                this.transform.parent = newParent.transform;
            }
            
        }
        else
        {
            if (sticky.activeSelf) sticky.SetActive(false);
        }
    }

    public void Attatch()
    {
        if (canProject)
        {
            gameObject.transform.position = projectPos;
            sticky.SetActive(false);
        }
        else
        {
            gameObject.SetActive(false);
            //acutally destory
            //Destroy(this);
        }
        
    }

    public void Respawner(StickyBlock b)
    {
        respawnCall += b.respawnItem;

    }

}