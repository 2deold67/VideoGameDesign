
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
//accessible from all scenes (only 1 player)
    public static int playerHealth;
    public static int playerDmg;
    public static int dmgMulti; //damage multiplier
    public static int lastAttack;
    public static float playerSpeed;
    public static bool seenIntro;
    public static companionManager[] companionList;
    public static companionManager defaultCompanion;
    public static GameObject player;
    public static GameObject fightPopup;

    public int minimapLayerMask = ~(1 << 8);//ignore minimap layer
    public GameObject Enemy;
    public GameObject UIManager;

    void Awake()
    {
        seenIntro = false;
    }
    // Use this for initialization
    void Start()
    {
        playerHealth = 50;
        playerDmg = 5;
        dmgMulti = 1;
        lastAttack = 1;
        playerSpeed = 3.0f;
        companionList = new companionManager[4];
        companionList[0] = defaultCompanion;
        player = this.gameObject;
        fightPopup = GameObject.Find("Fight Popup");

    }

    // Update is called once per frame
    void Update()
    {
        //checks if game is not paused and the player is not in a fight and if there is any popup on screen
        if ((!UIManager.GetComponent<UIManager>().isPaused && SceneManager.GetActiveScene().name != "fightScene") && fightPopup.gameObject.activeSelf == false )
        {
            //checks if there is a finger on screen
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Moved)
                {
                    RaycastHit hit;
                    Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

                    if (Physics.Raycast(ray, out hit, minimapLayerMask))
                        if (hit.collider != null)
                        {
                            GoToLocation(new Vector3(hit.point.x, transform.position.y, hit.point.z));
                        }
                }
            }
            //debug
           GoToMouse();
        }
        

        //else if (SceneManager.GetActiveScene().name != "fightScene")
        //{
        //    bool playerAttacked = false;
        //    if (playerAttacked)
        //    {
        //        Enemy.GetComponent<EnemyManager>().Attack(lastAttack, playerDmg);
        //    }

        //}

    }

    public void GoToLocation(Vector3 location)
    {
        transform.position = Vector3.Lerp(transform.position, location, playerSpeed * Time.deltaTime);
        //Debug.Log("Destination : " + location);

    }

    private void GoToMouse()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity,minimapLayerMask) && hit.collider.gameObject.tag != "Player")
            {
                Vector3 destination = new Vector3(hit.point.x, hit.point.y + 1, hit.point.z);

                transform.position = Vector3.Lerp(transform.position, destination, playerSpeed * Time.deltaTime);
                //Debug.Log("Destination : " + destination);
            }
        }
    }
  
}
