using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{

    public GameObject UI;

    public SceneFader sceneFader;

    public string menuSceneName = "Main Menu";

    public void Toggle()
    {
        UI.SetActive(!UI.activeSelf);

        if (UI.activeSelf)
        {
            Time.timeScale = 0f;
            FindObjectOfType<MusicScript>().Pause("MusicLevel");
        }
        else
        {
            Time.timeScale = 1f;
            FindObjectOfType<MusicScript>().Play("MusicLevel");
        }
    }

    public void Retry()
    {
        Toggle();
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
        FindObjectOfType<MusicScript>().Stop("MusicLevel");
        FindObjectOfType<MusicScript>().Play("MusicLevel");
    }

    public void Menu()
    {
        Toggle();
        sceneFader.FadeTo(menuSceneName);
        FindObjectOfType<MusicScript>().Stop("MusicLevel");
        FindObjectOfType<MusicScript>().Play("MusicaBG");
    }
}
