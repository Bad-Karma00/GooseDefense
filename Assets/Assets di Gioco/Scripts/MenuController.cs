using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour{

    public GameObject buttonpanel, LevelSelectPanel;

    private menuCameraMotion MenuCameraMotion;

    private void Awake()
    {
        MenuCameraMotion = Camera.main.GetComponent<menuCameraMotion>();
    }

    void Update()
    {
        
    }
    public void PlayGame()
    {
        MenuCameraMotion.switchPositionCamera(1);
        buttonpanel.SetActive(false);
        LevelSelectPanel.SetActive(true);
    }

    public void BackButton()
    {
        MenuCameraMotion.switchPositionCamera(0);
        buttonpanel.SetActive(true);
        LevelSelectPanel.SetActive(false);
    }
}
