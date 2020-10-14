using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;

    public Vector3 positionOffset;
   
    private CanvasGroup shop;

    private GameObject turret;

    private Renderer rend;

    private Color startColor;

    BuildManager buildManager;
    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
    }

    private void OnMouseDown()
    {

        if (EventSystem.current.IsPointerOverGameObject())
            return;
        
        if (buildManager.GetTurretToBuild() == null)
        {
            return;
        }

        if (turret != null)
        {
            Debug.Log("Un oca è già qui!");

        }
        if (buildManager.GetTurretToBuild() != null && turret == null) {
            GameObject turretToBuild = buildManager.GetTurretToBuild();
            turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
            rend.material.color = hoverColor;
        }
    }
    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
    
}
