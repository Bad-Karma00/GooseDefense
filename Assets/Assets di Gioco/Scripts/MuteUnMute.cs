using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteUnMute : MonoBehaviour
{
    public GameObject UI;

    public void Toggle()
    {
        

        if (UI.activeSelf)
        {
            FindObjectOfType<MusicScript>().Mute("MusicLevel");
            FindObjectOfType<MusicScript>().Mute("LaserShoot");
            FindObjectOfType<MusicScript>().Mute("MusicaBG");
            FindObjectOfType<MusicScript>().Mute("GunShoot");
            FindObjectOfType<MusicScript>().Mute("Explosion");
            FindObjectOfType<MusicScript>().Mute("RocketShoot");
        }
        else
        {
            FindObjectOfType<MusicScript>().UnMute("MusicLevel");
            FindObjectOfType<MusicScript>().UnMute("LaserShoot");
            FindObjectOfType<MusicScript>().UnMute("MusicaBG");
            FindObjectOfType<MusicScript>().UnMute("GunShoot");
            FindObjectOfType<MusicScript>().UnMute("Explosion");
            FindObjectOfType<MusicScript>().UnMute("RocketShoot");
        }
    }
}
