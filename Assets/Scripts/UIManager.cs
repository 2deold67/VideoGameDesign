using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

    public bool isPaused;
    public GameObject pauseMenu;
    public GameObject player;
    public GameObject enemy;

	// Use this for initialization
	void Start ()
    {
        isPaused = false;
        pauseMenu.SetActive(false);
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
}
