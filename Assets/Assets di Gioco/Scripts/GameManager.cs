using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool gameIsOver;
    public bool gameiswin = false;
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
        gameOverIU.SetActive(true);

    }

    public void WinLevel() {
        gameIsOver = true;
        gameiswin = true;
        CompleteLevelUI.SetActive(true);
    }
   
}
