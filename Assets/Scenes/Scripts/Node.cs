using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;

    public Vector3 positionOffset;

    public Color notEnoughMoneyColor;

    private CanvasGroup shop;

    [Header("Optional")]
    public GameObject turret;

    private Renderer rend;

    private Color startColor;

    BuildManager buildManager;
    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    private void OnMouseDown()
    {

        if (EventSystem.current.IsPointerOverGameObject())
            return;
        
        if (turret != null)
        {
            buildManager.SelectNode(this);
            return;
        }

        if (!buildManager.CanBuild)
        {
            return;
        }

        if (buildManager.CanBuild && turret == null) {
            buildManager.BuildTurretOn(this);
            if (buildManager.HasMoney)
            {
                rend.material.color = hoverColor;
            }
            else
            {
                rend.material.color = notEnoughMoneyColor;
            }
        }
    }
    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
    
}
