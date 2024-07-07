using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.XR.Interaction.Toolkit;

public delegate void OnDeselect();
public class StickyNote : MonoBehaviour
{
    public bool selected;
    private bool canProject;
    public GameObject projection;
    private Vector3 projectPos;
    public OnDeselect respawnCall;
    private IXRSelectInteractor c;
    private XRBaseInteractable d;

    private void OnEnable()
    {
        d = GetComponent<XRBaseInteractable>();
    }

    [ContextMenu("s")]
    public void OnSelection()
    {

        c = d.firstInteractorSelecting;
        selected = true;

    }

    [ContextMenu("d")]
    public void OnDisSelection()
    {

        selected = false;
        Attach();
        //respawn new sticky
        respawnCall?.Invoke();
    }


    void Update()
    {
        if (selected)
        {
            transform.GetChild(0).transform.localRotation = Quaternion.Euler(new Vector3(90, 180, 0));
            ProjectRay();
        }
    }

    public void ProjectRay()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, c.transform.forward, out hit))
        {
            Vector3 vec = hit.point;
            Vector3 a = gameObject.transform.position - hit.point;
            projectPos = vec + a * 0.05f;

            canProject = true;
            project(projectPos, hit);
        }
        else
        {
            canProject = false;
            project(Vector3.zero, hit);
        }

    }


    public void project(Vector3 vec, RaycastHit hit)
    {
        if (canProject)
        {
            projection.transform.position = vec;
            projection.transform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);

            if (!projection.activeSelf)
            {
                projection.SetActive(true);
            }
        }
        else
        {
            if (projection.activeSelf) projection.SetActive(false);
        }
    }

    public void Attach()
    {
        if (canProject)
        {
            gameObject.transform.position = projection.transform.position;
            gameObject.transform.transform.rotation = projection.transform.rotation;
            transform.GetChild(0).transform.localRotation = Quaternion.Euler(new Vector3(0, 180, 0));

            projection.SetActive(false);
        }
        else
        {
            Destroy(this);
        }

    }

    public void Respawner(StickyBlock b)
    {
        respawnCall += b.respawnItem;
    }
}