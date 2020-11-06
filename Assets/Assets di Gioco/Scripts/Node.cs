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

    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TurretBlueprint turretBlueprint;
    [HideInInspector]
    public bool isUpgraded=false;

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

    private void OnMouseOver()
    {
        
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
            BuildTurret(buildManager.getTurretToBuild());
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

    void BuildTurret (TurretBlueprint blueprint)
    {
        if (PlayerStats.Money < blueprint.cost)
        {
            Debug.Log("Non hai abbastanza soldi!");
            return;
        }
        PlayerStats.Money -= blueprint.cost;
        GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        Debug.Log("Oca piazzata!");
        turret = _turret;
        turretBlueprint = blueprint;
        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect,GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

    }

    public void UpgradeTurret() {
       
        if (PlayerStats.Money < turretBlueprint.upgradeCost)
        {
            Debug.Log("Non hai abbastanza soldi!");
            return;
        }
        PlayerStats.Money -= turretBlueprint.upgradeCost;

        Destroy(turret);
        GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
        Debug.Log("Oca potenziata!");
        turret = _turret;
        
        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        isUpgraded = true;


    }

    public void SellTurret()
    {
        if (isUpgraded == true)
        {
            PlayerStats.Money += turretBlueprint.getSellUp();
        }
        if (isUpgraded == false)
        {
            PlayerStats.Money += turretBlueprint.getSell();
        }

        GameObject effect = (GameObject)Instantiate(buildManager.sellEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);
        Destroy(turret);
        turretBlueprint = null;
        isUpgraded = false;
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
    
}
