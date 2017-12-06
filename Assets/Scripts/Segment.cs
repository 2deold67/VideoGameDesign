using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Segment : MonoBehaviour {

    private bool taken;
    public bool Taken
    {
        get
        {
            return taken;
        }
        set
        {
            taken = value;
            if (taken)
            {
                GetComponent<Renderer>().material = Red;
            }
            else
            {
                GetComponent<Renderer>().material = Green;
            }
        }
    }

 
    public Material SegmentMat;
    public Material Green;
    public Material Red;
    public Inventory R_Inventory;
    public GameObject Furniture;
	void Start ()
    {
        
	}
	
	
	void Update ()
    {
        if (R_Inventory == null)
        {
            R_Inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
            print(GameObject.FindGameObjectWithTag("Inventory"));

        }
    }

    private void OnMouseDown()
    {
        if (!Taken)
        {
            if (R_Inventory.SelectedFurniture != null)
            {
                Furniture = R_Inventory.SelectedFurniture;
                Furniture.transform.parent = this.transform;
                Furniture.transform.localPosition = Vector3.zero;
                R_Inventory.RemoveSelectedIcon();
                Taken = true;
                R_Inventory.SelectedFurniture = null;
            }
        }
    }
}
