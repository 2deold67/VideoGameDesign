
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{

    public float playerSpeed;
    public GameObject UIManager;
    public float playerHealth;
    public float playerDmg;
    public float dmgMulti; //damage multiplier
    public companionManager[] companionList;
    public companionManager defaultCompanion;
    public int lastAttack;
    public GameObject Enemy;

    // Use this for initialization
    void Start()
    {
        companionList = new companionManager[4];
        companionList[0] = defaultCompanion;
        playerSpeed = 3.0f;
        playerHealth = 50.0f;
        playerDmg = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //checks ifgame is not paused and the [player is not in a fight
        if (!UIManager.GetComponent<UIManager>().isPaused && SceneManager.GetActiveScene().name != "fightScene")
        {
            //checks if there is a finger on screen
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Moved)
                {
                    RaycastHit hit;
                    Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

                    if (Physics.Raycast(ray, out hit))
                        if (hit.collider != null)
                        {
                            GoToLocation(new Vector3(hit.point.x, transform.position.y, hit.point.z));
                        }
                }
            }
            //debug
            GoToMouse();
        }

        else if(SceneManager.GetActiveScene().name != "fightScene")
        {
            bool playerAttacked = false;
            if (playerAttacked)
            {
                Enemy.GetComponent<EnemyManager>().Attack(lastAttack, playerDmg);
            }
            
        }

    }

    public void GoToLocation(Vector3 location)
    {

        transform.position = Vector3.Lerp(transform.position, location, playerSpeed * Time.deltaTime);
        Debug.Log("Destination : " + location);

    }

    private void GoToMouse()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.tag != "Player")
            {
                Vector3 destination = new Vector3(hit.point.x, hit.point.y + 1, hit.point.z);

                transform.position = Vector3.Lerp(transform.position, destination, playerSpeed * Time.deltaTime);
                Debug.Log("Destination : " + destination);
            }
        }
    }

    public void takeDamage(float damage)
    {
        playerHealth -= damage;
    }
}
