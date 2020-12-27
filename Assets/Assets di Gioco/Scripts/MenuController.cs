using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour{

    public GameObject buttonpanel, LevelSelectPanel, TutorialPanel;

    private menuCameraMotion MenuCameraMotion;

    private void Awake()
    {
        MenuCameraMotion = Camera.main.GetComponent<menuCameraMotion>();
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
        TutorialPanel.SetActive(false);
    }

    public void Tutorial()
    {
        MenuCameraMotion.switchPositionCamera(2);
        buttonpanel.SetActive(false);
        TutorialPanel.SetActive(true);
    }
}
