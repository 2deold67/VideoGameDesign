using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Vector3 [] enemySpawnPoint;
    public Object enemyPrefab;
    public GameObject player;
	// Use this for initialization
	void Start ()
    {
        enemySpawnPoint = new Vector3[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            enemySpawnPoint[i] = transform.TransformPoint(transform.GetChild(i).transform.position);
            Debug.Log("enemy Spawns: "+enemySpawnPoint[i]);
            Instantiate(enemyPrefab, enemySpawnPoint[i], Quaternion.RotateTowards(transform.rotation, player.transform.rotation, 180.0f));
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
