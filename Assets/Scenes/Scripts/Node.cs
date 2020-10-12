using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor;

    public Vector3 positionOffset;

    private GameObject turret;

    private Renderer rend;

    private Color startColor;
    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    private void OnMouseDown()
    {
        rend.material.color = hoverColor;
        if (turret != null)
        {
            Debug.Log("Un oca è già qui!");

        }
        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        turret = (GameObject) Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
    }
    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
    
}
