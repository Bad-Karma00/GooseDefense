using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeUIScript : MonoBehaviour
{

    public GameObject UI;
    public Text upgradeCost;
    private Node target;
    public Button upgradeButton;

    public void SetTarget(Node _target)
    {
        UI.SetActive(true);
        target = _target;
        transform.position = target.GetBuildPosition();
        if (!target.isUpgraded)
        {
            upgradeCost.text = "$" + target.turretBlueprint.upgradeCost;
            upgradeButton.interactable = true;
        }
        else
        {
            upgradeCost.text = "FATTO!";
            upgradeButton.interactable = false;
        }

   
    }

    public void Hide()
    {
        UI.SetActive(false);
    }

    public void Upgrade() {
        target.UpgradeTurret();
        BuildManager.instance.DeselectNode();
    }
}
