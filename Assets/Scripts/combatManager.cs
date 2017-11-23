using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class combatManager : MonoBehaviour {
    public GameObject pauseMenu;     
    public GameObject player;
    public GameObject enemy;
    public GameObject UIManager;
    public companionManager[] companionList;
    public companionManager defaultCompanion;
    public Button Attack;
    public Slider enemyhealth;
    public Slider playerhealth;
    int enemyAttckChoice;
    int playerAttackChoice;

    // Use this for initialization
    void Start() {
        enemyhealth.maxValue = enemy.GetComponent<EnemyManager>().enemyHealth;
        enemyhealth.normalizedValue = 1;
        playerhealth.maxValue = player.GetComponent<PlayerController>().playerHealth;
        playerhealth.normalizedValue = 1;
    }
	
	// Update is called once per frame
	void Update () {
       
        if (!UIManager.GetComponent<UIManager>().isPaused)          // check if the games not paused then do comnbat calcs
        {
            //player health what do
            if (player.GetComponent<PlayerController>().playerHealth <= 0)
            {
                Debug.Log("Player dead");
            }


            //enemmy health
            if (enemy.GetComponent<EnemyManager>().enemyHealth <= 0)
            {
                Debug.Log("enemy dead");
            }

            //eneemy attack 
            enemyAttckChoice = enemy.GetComponent<EnemyManager>().enemyAttack;

            
        }
       
        
    }

    public void Combat()
    {
        ///Works out the attck values for the players

        enemy.GetComponent<EnemyManager>().EnemyAttack(); // calls the random functiopn to set the enemeys attack 
        enemyAttckChoice = enemy.GetComponent<EnemyManager>().enemyAttack;
        Debug.Log(enemyAttckChoice);
        playerAttackChoice = player.GetComponent<PlayerController>().lastAttack; //  grabs the players last attack value 
        Debug.Log(playerAttackChoice);

        // Actual combat calculations


        if (playerAttackChoice == enemyAttckChoice)
        {
            //DO NOTHING 
            Debug.Log("Embarassingly you both have the same idea");
            // NO DAMAGE 
        }
        if (playerAttackChoice == 1) // sheild bash 
        {
            if (enemyAttckChoice == 2) // dagger
            {
                //lose
                Debug.Log("The enemy counterattcks");
                player.GetComponent<PlayerController>().playerHealth = player.GetComponent<PlayerController>().playerHealth - enemy.GetComponent<EnemyManager>().enemyDamage;
                playerhealth.value = playerhealth.value - enemy.GetComponent<EnemyManager>().enemyDamage;
            }

            else if (enemyAttckChoice == 3)//sword
            {
                //win
                enemy.GetComponent<EnemyManager>().enemyHealth = enemy.GetComponent<EnemyManager>().enemyHealth - player.GetComponent<PlayerController>().playerDmg;
                enemyhealth.value = enemyhealth.value - player.GetComponent<PlayerController>().playerDmg;
                Debug.Log("You bash them into oblivion");
            }
        }
            if (playerAttackChoice == 2) //  dagger 
            {
                if (enemyAttckChoice == 1)//sheild bash 
                {
                //win
                enemy.GetComponent<EnemyManager>().enemyHealth = enemy.GetComponent<EnemyManager>().enemyHealth - player.GetComponent<PlayerController>().playerDmg;
                enemyhealth.value = enemyhealth.value - player.GetComponent<PlayerController>().playerDmg;
                Debug.Log("You counterattck the enemy");
                }

                else if (enemyAttckChoice == 3) // sword
                {
                //lose

                player.GetComponent<PlayerController>().playerHealth = player.GetComponent<PlayerController>().playerHealth - enemy.GetComponent<EnemyManager>().enemyDamage;
                playerhealth.value = playerhealth.value - enemy.GetComponent<EnemyManager>().enemyDamage;
                Debug.Log("The enemy gets a few good hits in");
                }
        }
            if (playerAttackChoice == 3) // sword
            {
                if (enemyAttckChoice == 1)//shield bash 
                {
                //lose

                player.GetComponent<PlayerController>().playerHealth = player.GetComponent<PlayerController>().playerHealth - enemy.GetComponent<EnemyManager>().enemyDamage;
                playerhealth.value = playerhealth.value - enemy.GetComponent<EnemyManager>().enemyDamage;
                Debug.Log("the enemy charges you");
                }

                else if (enemyAttckChoice == 2)//dagger
                {
                //win
                enemy.GetComponent<EnemyManager>().enemyHealth = enemy.GetComponent<EnemyManager>().enemyHealth - player.GetComponent<PlayerController>().playerDmg;
                enemyhealth.value = enemyhealth.value - player.GetComponent<PlayerController>().playerDmg;
                Debug.Log("you fuck em up");
                }
            }

    }
}
