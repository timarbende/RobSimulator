using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyNote : MonoBehaviour
{
    public bool selected;
    private bool canProject;
    public GameObject sticky;



    public void OnSelection()
    {
        selected = true;

    }
    public void OnDisSelection()
    {

        selected = false;
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
                  Vector3 f=  vec+a*0.05f;
                    print(vec + "name " +f);
                 //   gameObject.transform.position = vec;
                    canProject = true;
                    project(f);
                }
                else
                {
                    canProject = false;
                    project(Vector3.zero);
                }
        
    }


    public void project(Vector3 vector)
    {
        if (canProject)
        {
            sticky.transform.position = vector;
            if (!sticky.activeSelf) sticky.SetActive(true);
        }
        else
        {
            if (sticky.activeSelf) sticky.SetActive(false);
        }
    }
    
    
}