using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{

    BuildManager buildManager;
    

    private void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void PurchaseStandardTurret()
    {
        Debug.Log("Oca con pistola selezionata");
        buildManager.SetTurretToBuild(buildManager.standardTurretPrefab);
    }

    public void PurchaseRocketTurret()
    {
        Debug.Log("Oca con lanciarazzi selezionata");
        buildManager.SetTurretToBuild(buildManager.rocketTurretPrefab);
    }

    public void PurchaseLaserTurret()
    {
        Debug.Log("Oca laser selezionata");
    }

}
