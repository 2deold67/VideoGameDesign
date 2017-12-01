using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

    public bool isPaused;
    public GameObject pauseMenu;
    public GameObject player;
    public GameObject enemy;
    public GameObject optionsPanel;
    public GameObject musicSource;
    public GameObject soundIcon;
    public GameObject musicIcon;
    public Slider soundSlider;
    public Slider musicSlider;
    public Sprite soundSprite;
    public Sprite musicSprite;
    public Sprite muteSprite;
    public Sprite noMusicSprite;
    bool isMute;

    // Use this for initialization
    void Start ()
    {
        if (SceneManager.GetActiveScene().name != "mainMenu")
        {
            isPaused = false;
            pauseMenu.SetActive(false);
        }
        else
        {
            musicSource.GetComponent<AudioSource>().Play();
            musicSource.GetComponent<AudioSource>().volume = 0.5f;
            AudioListener.volume = 0.5f;
            musicSlider.value = musicSource.GetComponent<AudioSource>().volume;
            soundSlider.value = AudioListener.volume;
            optionsPanel.SetActive(false);
            soundIcon.GetComponent<Image>().sprite = soundSprite;
            musicIcon.GetComponent<Image>().sprite = musicSprite;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
	}

    public void Pause()
    {
        if (!isPaused)
        {
            isPaused = true;
            pauseMenu.SetActive(true);

        }
        else
        {
            isPaused = false;
            pauseMenu.SetActive(false);
        }
    }

    public void ShieldBash()
    {
        player.GetComponent<PlayerController>().lastAttack = 1;
       //Debug.Log(player.GetComponent<PlayerController>().lastAttack);
    }
    public void Dagger()
    {
        player.GetComponent<PlayerController>().lastAttack = 2;
       // Debug.Log(player.GetComponent<PlayerController>().lastAttack);
    }
    public void Sword()
    {
        player.GetComponent<PlayerController>().lastAttack = 3;
        
        //Debug.Log(player.GetComponent<PlayerController>().lastAttack);
    }

    public void playGame()
    {
        SceneManager.LoadScene("mainScene");
    }

    public void musicMute()
    {
        musicSource.GetComponent<AudioSource>().mute = !musicSource.GetComponent<AudioSource>().mute;
        if (musicIcon.GetComponent<Image>().sprite == musicSprite)
        {
            musicIcon.GetComponent<Image>().sprite = noMusicSprite;

        }

        else if (musicIcon.GetComponent<Image>().sprite == noMusicSprite)

        {
            musicIcon.GetComponent<Image>().sprite = musicSprite;

        }
        //musicSlider.value = musicSource.GetComponent<AudioSource>().volume;
        Debug.Log("Music Mute");
    }
    public void soundMute()
    {
       
       AudioListener.volume = isMute ? 0:1;
        if (soundIcon.GetComponent<Image>().sprite == soundSprite)
        {
            soundIcon.GetComponent<Image>().sprite = muteSprite;

        }

        else if (soundIcon.GetComponent<Image>().sprite == muteSprite)

        {
            soundIcon.GetComponent<Image>().sprite = soundSprite;

        }

        //soundSlider.value = AudioListener.volume;
        Debug.Log("Sound Mute");
    }

    public void SoundSlider()
    {
        AudioListener.volume = soundSlider.value;
        Debug.Log("Sound: " + AudioListener.volume);
    }
    public void MusicSlider()
    {
        musicSource.GetComponent<AudioSource>().volume = musicSlider.value;
        Debug.Log("Music: " + musicSource.GetComponent<AudioSource>().volume);
    }

    public void OptionsPanel()
    {
        optionsPanel.SetActive(!optionsPanel.activeSelf);
    }
}
