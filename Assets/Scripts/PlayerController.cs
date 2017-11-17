using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float movement_speed;

    // Use this for initialization
    void Start()
    {
        movement_speed = 3.0f;
    }

    // Update is called once per frame
    void Update()
    {
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
                        GoToLocation(new Vector3 (hit.point.x, transform.position.y,hit.point.z));
                    }
            }
        }
        GoToMouse();
    }

    public void GoToLocation(Vector3 location)
    {

        transform.position = Vector3.Lerp(transform.position, location, movement_speed * Time.deltaTime);
        Debug.Log("Destination : " + location);

    }

    private void GoToMouse()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                Vector3 destination = new Vector3(hit.point.x, hit.point.y + 1, hit.point.z);

                transform.position = Vector3.Lerp(transform.position, destination, movement_speed * Time.deltaTime);
                Debug.Log("Destination : " + destination);
            }
        }
    }
}
