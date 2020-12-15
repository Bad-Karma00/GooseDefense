using System.Collections;
using UnityEngine.Audio;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    public SceneFader fader;
    public Button[] levelbuttons;
    public Button menubutton;
    public string menuName = "VeroMenu";

    void Start()
    {
        menubutton.interactable = true;
        int levelReached = AuthHandler.utente.level;
        for (int i = 0; i < levelbuttons.Length; i++) {
            if(i+1>levelReached)
            levelbuttons[i].interactable = false;

        }
    }

    public void Select(string Levelname)
    {
        fader.FadeTo(Levelname);
        FindObjectOfType<MusicScript>().Play("MusicLevel");
        FindObjectOfType<MusicScript>().Stop("MusicaBG");


    }
    public void Menu() {
        fader.FadeTo(menuName);
    }
}
