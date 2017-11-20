using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {
    
    public float enemyHealth;
    public int dmgMulti;
	// Use this for initialization
	void Start () {
        enemyHealth = 50.0f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Attack(int playerAttack, float playerDamage)
    {
        int currentAttack = RandomAttack();//get random attack for enemy
        if (currentAttack == playerAttack)//same attack as player
        {
            dmgMulti = 1;
        }
        else if (currentAttack > playerAttack)//enemy attack stronger
        {
            dmgMulti = 2;
        }
        else//enemy attack weaker
        {
            playerDamage *= 2;
        }
        takeDamage(playerDamage);
    }
    int  RandomAttack()
    {
        return (int )Random.Range(1, 3);
    }

    void takeDamage(float damage)
    {
        enemyHealth -= damage;
    }
}
