using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialScript : MonoBehaviour
{
    public int index;

    public List<GameObject> immagini = new List<GameObject>();

    public GameObject NextButton;
    public GameObject BackButton;

    private void Update()
    {
        if (index == 0)
        {
            BackButton.SetActive(false);
        }
    }

    public void NextImmagine()
    {
        index++;
        if (index == 0)
        {
            BackButton.SetActive(true);
            immagini[index].SetActive(true);
        }
        if (index == 1)
        {
            BackButton.SetActive(true);
            immagini[index - 1].SetActive(false);
            immagini[index].SetActive(true);
        }
        if (index == 2)
        {
            immagini[index - 1].SetActive(false);
            immagini[index].SetActive(true);
        }
        if (index == 3)
        {
            
            immagini[index - 1].SetActive(false);
            immagini[index].SetActive(true);
        }
        if (index == 4)
        {
            immagini[index - 1].SetActive(false);
            immagini[index].SetActive(true);
        }
        if (index == 5)
        {
            NextButton.SetActive(false);
            immagini[index - 1].SetActive(false);
            immagini[index].SetActive(true);
        }

    }

    public void PrevImmagine()
    {
        if (index == 1)
        {
            
            immagini[index].SetActive(false);
            immagini[index - 1].SetActive(true);
        }
        if (index == 2)
        {
            
            immagini[index].SetActive(false);
            immagini[index - 1].SetActive(true);
        }
        if (index == 3)
        {
            
            immagini[index].SetActive(false);
            immagini[index - 1].SetActive(true);
        }
        if (index == 4)
        {
            immagini[index].SetActive(false);
            immagini[index - 1].SetActive(true);
        }
        if (index == 5)
        {
            NextButton.SetActive(true);
            immagini[index].SetActive(false);
            immagini[index - 1].SetActive(true);
        }
        index--;
    }
}
