using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [HideInInspector]
    public bool gameiswin = false;

    public static bool gameIsOver;
    public GameObject gameOverIU;
    public GameObject CompleteLevelUI;

    private void Start()
    {
        gameIsOver = false;
    }

    void Update()
    {
        if (gameIsOver)
        {
            return;
        }

        if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }
    }

    public void EndGame()
    {
        gameIsOver = true;
        FindObjectOfType<MusicScript>().Stop("MusicLevel");
        gameOverIU.SetActive(true);

    }

    public void WinLevel() {
        gameIsOver = true;
        FindObjectOfType<MusicScript>().Stop("MusicLevel");
        gameiswin = true;
        CompleteLevelUI.SetActive(true);
    }
   
}
