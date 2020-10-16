using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{

    BuildManager buildManager;
    

    public TurretBlueprint standardTurret;
    public TurretBlueprint missleLauncher;
    public TurretBlueprint laserTurret;


    private void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void SelectStandardTurret()
    {
        Debug.Log("Oca con pistola selezionata");
        buildManager.SelectTurretToBuild(standardTurret);
    }

    public void SelectRocketTurret()
    {
        Debug.Log("Oca con lanciarazzi selezionata");
        buildManager.SelectTurretToBuild(missleLauncher);
    }

    public void SelectLaserTurret()
    {
        Debug.Log("Oca laser selezionata");
        buildManager.SelectTurretToBuild(laserTurret);
    }

}
