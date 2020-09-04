using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    //private AudioListener audioListener;
    //private bool musicIsMuted;
    //private bool sfxIsMuted;
    private Music music;
    public Button musicButton;
    public Sprite musicOnSprite;
    public Sprite musicOffSprite;


    void Start()
    {
        music = GameObject.FindObjectOfType<Music>();
        UpdateIconAndVolume();
    }

    public void PauseMusic()
    {
        music.ToggleSound();
        UpdateIconAndVolume();
    }

    public void UpdateIconAndVolume()
    {
        if (PlayerPrefs.GetInt("Muted", 0) == 0)
        {
            AudioListener.volume = 1;
            musicButton.GetComponent<Image>().sprite = musicOnSprite;
        }
        else
        {
            AudioListener.volume = 0;
            musicButton.GetComponent<Image>().sprite = musicOffSprite;
        }
      }






    // Start is called before the first frame update
    /*void Start()
    {
        musicIsMuted = true;
        sfxIsMuted = true;
    }*/

    // Update is called once per frame



    /* public void muteMusic()
     {
         musicIsMuted = !musicIsMuted;
         AudioListener.pause = musicIsMuted;
     }
     public void muteSfx()
     {
         sfxIsMuted = !sfxIsMuted;
         AudioListener.pause = sfxIsMuted;
     }*/
}
