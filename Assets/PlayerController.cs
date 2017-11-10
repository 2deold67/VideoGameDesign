using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float movement_speed;

    // Use this for initialization
    void Start ()
    {
        movement_speed = 5;		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit; 
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                Vector3 destination = hit.point;
                transform.position = Vector3.Lerp(transform.position, destination, movement_speed * Time.deltaTime);
                Debug.Log("Destination : " + destination);
            }
        }
        
	}

}
