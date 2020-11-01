using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteLevel : MonoBehaviour
{

    public SceneFader sceneFader;
    public string menuSceneName = "Main Menu";
    public int levelToUnlock = 2;
    public string next = "Livello2";

    public void Menu()
    {
        sceneFader.FadeTo(menuSceneName);
    }

    public void Continue() {
        Debug.Log("LIVELLO COMPLETATO");

        if (PlayerPrefs.GetInt("levelReached") < levelToUnlock)
        {
            PlayerPrefs.SetInt("levelReached", levelToUnlock);
        }
        sceneFader.FadeTo(next);

    }
}
