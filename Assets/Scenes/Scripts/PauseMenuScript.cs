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
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void Retry()
    {
        Toggle();
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        Toggle();
        sceneFader.FadeTo(menuSceneName);
    }
}
