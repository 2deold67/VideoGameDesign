using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyManager : MonoBehaviour {

    public int enemyHealth;
    public int enemyDamage;
    public int enemyAttack;
    public int dmgMulti;
    public GameObject fightPopup;
    // Use this for initialization
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
    void Start () {
        //enemyHealth = 50;
        //enemyDamage = 2;
        fightPopup = GameObject.FindGameObjectWithTag("FightPopup");
        fightPopup.SetActive(false);
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
        if (fightPopup.gameObject.activeSelf ==false)
        {
            fightPopup.gameObject.SetActive(true);

        }

    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    Debug.Log("poop");
    //}
    void Update()
    {
        if (fightPopup.gameObject.activeSelf == true && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Loading Fight");
            SceneManager.LoadScene("fightScene");
        }
    }

}
