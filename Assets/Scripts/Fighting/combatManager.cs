using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class combatManager : MonoBehaviour {
    public GameObject pauseMenu;     
    public GameObject player;
    public GameObject enemy;
    public GameObject UIManager;
    public GameObject attackText;
    public companionManager[] companionList;
    public companionManager defaultCompanion;
    public Slider enemyhealth;
    public Slider playerhealth;
    int enemyAttckChoice;
    int playerAttackChoice;

    // Use this for initialization
    void Start()
    {
        player = PlayerController.player;
        enemyhealth.maxValue = enemy.GetComponent<EnemyManager>().enemyHealth;
        enemyhealth.normalizedValue = 1;
        playerhealth.maxValue = PlayerController.playerHealth;
        playerhealth.normalizedValue = 1;
        attackText.SetActive(false);
        PopupDamageTextController.Initialize();
    }
	
	// Update is called once per frame
	void Update ()
    {
       
        if (!UIManager.GetComponent<UIManager>().isPaused)          // check if the games not paused then do comnbat calcs
        {
            //player health what do
            if (PlayerController.playerHealth <= 0)
            {
                Debug.Log("Player dead");
            }


            //enemmy health
            if (enemy.GetComponent<EnemyManager>().enemyHealth <= 0)
            {
                Debug.Log("enemy dead");

                SceneManager.LoadScene("mainScene");
                
            }

            //enemy attack 
            enemyAttckChoice = enemy.GetComponent<EnemyManager>().enemyAttack;  
        }
    }
    public void ButtonAttack()
    {
        attackText.SetActive(!attackText.activeSelf);
    }

    public void Combat()
    {
        ///Works out the attck values for the players
        if (!UIManager.GetComponent<UIManager>().isPaused)
        {

                enemy.GetComponent<EnemyManager>().EnemyAttack(); // calls the random functiopn to set the enemeys attack 
                enemyAttckChoice = enemy.GetComponent<EnemyManager>().enemyAttack;
                Debug.Log("enemy attack:" + enemyAttckChoice);
                playerAttackChoice = PlayerController.lastAttack; //  grabs the players last attack value 
                Debug.Log("player attack:" + playerAttackChoice);

                // Actual combat calculations

                Debug.Log("player Health =" + PlayerController.playerHealth);
                Debug.Log("Enemy health = " + enemy.GetComponent<EnemyManager>().enemyHealth);

            if (PlayerController.defaultCompanion.GetComponent<companionManager>().TryHit() == false)
            {
                if (playerAttackChoice == enemyAttckChoice)
                {
                    attackText.GetComponentInChildren<Text>().text = "The enemy counterattcks";
                    //DO NOTHING 
                    attackText.SetActive(true);
                    attackText.GetComponentInChildren<Text>().text = ("Embarassingly you both have the same idea");
                    // NO DAMAGE 
                }
                if (playerAttackChoice == 1) // sheild bash 
                {
                    if (enemyAttckChoice == 2) // dagger
                    {
                        //lose
                        attackText.SetActive(true);
                        attackText.GetComponentInChildren<Text>().text = "The enemy counterattcks";
                        PlayerController.playerHealth -= enemy.GetComponent<EnemyManager>().enemyDamage;
                        playerhealth.value -= enemy.GetComponent<EnemyManager>().enemyDamage;
                    }

                    else if (enemyAttckChoice == 3)//sword
                    {
                        //win
                        attackText.SetActive(true);
                        enemy.GetComponent<EnemyManager>().enemyHealth -= PlayerController.playerDmg;
                        enemyhealth.value -= PlayerController.playerDmg;

                        PopupDamageTextController.CreatePopupDamage(PlayerController.playerDmg.ToString(), enemy.transform);

                        attackText.GetComponentInChildren<Text>().text = "You bash them into oblivion";
                    }
                }
                else if (playerAttackChoice == 2) //  dagger 
                {
                    if (enemyAttckChoice == 1)//sheild bash 
                    {
                        //win
                        attackText.SetActive(true);
                        enemy.GetComponent<EnemyManager>().enemyHealth -= PlayerController.playerDmg;
                        enemyhealth.value -= PlayerController.playerDmg;
                        attackText.GetComponentInChildren<Text>().text = "You counterattck the enemy";
                    }

                    else if (enemyAttckChoice == 3) // sword
                    {
                        //lose
                        attackText.SetActive(true);
                        PlayerController.playerHealth -= enemy.GetComponent<EnemyManager>().enemyDamage;
                        playerhealth.value -= enemy.GetComponent<EnemyManager>().enemyDamage;
                        attackText.GetComponentInChildren<Text>().text = "The enemy gets a few good hits in";
                    }
                }
                else if (playerAttackChoice == 3) // sword
                {
                    if (enemyAttckChoice == 1)//shield bash 
                    {
                        //lose
                        attackText.SetActive(true);
                        PlayerController.playerHealth -= enemy.GetComponent<EnemyManager>().enemyDamage;
                        playerhealth.value -= enemy.GetComponent<EnemyManager>().enemyDamage;
                        attackText.GetComponentInChildren<Text>().text = "the enemy charges you";
                    }

                    else if (enemyAttckChoice == 2)//dagger
                    {
                        //win
                        attackText.SetActive(true);
                        enemy.GetComponent<EnemyManager>().enemyHealth -= PlayerController.playerDmg;
                        enemyhealth.value -= PlayerController.playerDmg;
                        attackText.GetComponentInChildren<Text>().text = "you fuck em up";
                    }
                }

            }
            else
            {
                attackText.SetActive(true);
                attackText.GetComponentInChildren<Text>().text = "You companion hits the enemy!";
            }

        }
    }


}
