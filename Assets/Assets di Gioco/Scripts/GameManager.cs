using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Proyecto26;

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
        FindObjectOfType<MusicScript>().Stop("GunShoot");
        FindObjectOfType<MusicScript>().Stop("Explosion");
        FindObjectOfType<MusicScript>().Stop("RocketShoot");
        FindObjectOfType<MusicScript>().Stop("LaserShoot");
        gameOverIU.SetActive(true);

    }

    public void WinLevel() {
        gameIsOver = true;
        FindObjectOfType<MusicScript>().Stop("MusicLevel");
        FindObjectOfType<MusicScript>().Stop("GunShoot");
        FindObjectOfType<MusicScript>().Stop("Explosion");
        FindObjectOfType<MusicScript>().Stop("RocketShoot");
        FindObjectOfType<MusicScript>().Stop("LaserShoot");
        gameiswin = true;
        if (AuthHandler.utente.level ==PlayerPrefs.GetInt("livelloCorrente")) {
            AuthHandler.utente.level++;
            DatabaseHandler.PostUser(AuthHandler.utente, AuthHandler.identificativo, () => { }, AuthHandler.token);
        }
            CompleteLevelUI.SetActive(true);
        
    }
}
   

