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

    }
    void Start () {
        //enemyHealth = 50;
        //enemyDamage = 2;
        fightPopup = PlayerController.fightPopup;
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
        if (fightPopup.gameObject.activeSelf == false)
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
        if (GameObject.Find("Fight Popup"))
        {
            if (fightPopup.gameObject.activeSelf == true && Input.GetKeyDown(KeyCode.Return))
            {
                EnterFight();
            }
            else if (fightPopup.gameObject.activeSelf == true && Input.GetKeyDown(KeyCode.N))
            {
                Debug.Log("You bailed");
                GetComponent<SphereCollider>().isTrigger = true;
                fightPopup.gameObject.SetActive(false);
                StartCoroutine(WaitForPopup());



            }
        } 
    }

    public void EnterFight()
    {
        SceneManager.LoadScene("fightScene");
    }



    IEnumerator WaitForPopup()
    {
        print(Time.time);

        yield return new WaitForSeconds(1);
        print(Time.time);
        GetComponent<SphereCollider>().isTrigger = false;
    }
}

