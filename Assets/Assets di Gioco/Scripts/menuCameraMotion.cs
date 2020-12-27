using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuCameraMotion : MonoBehaviour
{
    public GameObject MainMenuPoint;
    public GameObject LevelSelectPoint;
    public GameObject TutorialPoint;

    private List<GameObject> position = new List<GameObject>();

    private void Awake()
    {
        position.Add(MainMenuPoint);
    }
    
    void Update()
    {
        MoveToPosition();
    }

    void MoveToPosition()
    {
        if(position.Count > 0)
        {
            transform.position = Vector3.Lerp(transform.position, position[0].transform.position, 2.5f * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, position[0].transform.rotation, 2.5f * Time.deltaTime);
        }
    }

    public void switchPositionCamera(int index)
    {
        position.RemoveAt(0);
        if (index == 0)
        {
            position.Add(MainMenuPoint);
        }
        if(index == 1)
        {
            position.Add(LevelSelectPoint);
        }
        if(index == 2)
        {
            position.Add(TutorialPoint);
        }
    }
}
