using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeUIScript : MonoBehaviour
{

    public GameObject UI;

    private Node target;

    public void SetTarget(Node _target)
    {
        UI.SetActive(true);
        target = _target;
        transform.position = target.GetBuildPosition();
    }

    public void Hide()
    {
        UI.SetActive(false);
    }
}
