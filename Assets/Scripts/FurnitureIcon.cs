using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnitureIcon : MonoBehaviour {

    public GameObject furniture;
    public Inventory R_Inventory;
	// Use this for initialization
	void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (R_Inventory == null)
        {
            R_Inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
            print(GameObject.FindGameObjectWithTag("Inventory"));
        }	
	}

    public void OnPress()
    {
        print("Test");
        R_Inventory.SelectedFurniture = Instantiate(furniture);
        R_Inventory.SelectIcon(this.gameObject);
    }

    

}
