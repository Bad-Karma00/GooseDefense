using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteLevel : MonoBehaviour
{

    public SceneFader sceneFader;
    public string levelSceneName = "LevelSelect";
    public int levelToUnlock = 2;
    public string next = "Livello2";
    

   
    public void LevelSelection()
    {
        Debug.Log("LIVELLO COMPLETATO");
        FindObjectOfType<MusicScript>().Stop("MusicLevel");
        FindObjectOfType<MusicScript>().Play("MusicaBG");

        if (PlayerPrefs.GetInt("levelReached") < levelToUnlock)
        {
            PlayerPrefs.SetInt("levelReached", levelToUnlock);
        }
        sceneFader.FadeTo(levelSceneName);
    }

    public void Continue() {
        Debug.Log("LIVELLO COMPLETATO");
        FindObjectOfType<MusicScript>().Stop("MusicLevel");
        FindObjectOfType<MusicScript>().Play("MusicLevel");

        if (PlayerPrefs.GetInt("levelReached") < levelToUnlock)
        {
            PlayerPrefs.SetInt("levelReached", levelToUnlock);
        }
        sceneFader.FadeTo(next);

    }
}
