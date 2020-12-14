using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameOver : MonoBehaviour
{
   
    public SceneFader sceneFader;

    public string menuSceneName = "VeroMenu";

    public void Retry()
    {
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
        FindObjectOfType<MusicScript>().Stop("MusicLevel");
        FindObjectOfType<MusicScript>().Play("MusicLevel");
    }

    public void Menu()
    {
        sceneFader.FadeTo(menuSceneName);
        FindObjectOfType<MusicScript>().Stop("MusicLevel");
        FindObjectOfType<MusicScript>().Play("MusicaBG");
    }
}
