using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    public int enemyHealth;
    public int enemyDamage;
    public int enemyAttack;
    public int dmgMulti;
	// Use this for initialization
	void Start () {
        //enemyHealth = 50;
        //enemyDamage = 2;

    }
	
	// Update is called once per frame
	

    public void EnemyAttack()
    {
        enemyAttack = RandomAttack();//get random attack for enemy
   
    }
    int  RandomAttack()
    {
        return (int )Random.Range(1, 4);
    }


    private void OnCollisionStay(Collision collision)
    {
  
        Debug.Log("poop");
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    Debug.Log("poop");
    //}


}
