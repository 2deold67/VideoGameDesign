using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

    public bool isPaused;
    public GameObject pauseMenu;
	// Use this for initialization
	void Start ()
    {
        isPaused = false;
        pauseMenu.SetActive(false);
    }
	
	// Update is called once per frame
	void Update ()
    {
		
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
}
