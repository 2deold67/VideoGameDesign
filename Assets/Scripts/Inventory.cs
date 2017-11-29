using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    public List<GameObject> FurnitureInventory;
    public List<GameObject> FurnitureIcons;
    public GameObject InventoryPanel;

    // Use this for initialization
    void Start ()
    {
        float leftColumn = -50,
              rightColumn = 50;
        int rowCount = 0;

        for (int i = 0; i < FurnitureIcons.Count; i++)
        {
            GameObject temp = Instantiate(FurnitureIcons[i], InventoryPanel.transform);
            //temp.GetComponent<RectTransform>().anchorMin = new Vector2(0, 1);
            //temp.GetComponent<RectTransform>().anchorMax = new Vector2(0, 1);
            if (!IsOdd(i))
            {
                temp.transform.localPosition = new Vector3(leftColumn, 100 + (-90 * rowCount));
            }
            else
            {
                temp.transform.localPosition = new Vector3(rightColumn, 100 + (-90 * rowCount));
                rowCount++;
            }
        }
	}

    private bool IsOdd(int value)
    {
        return value % 2 != 0;
    }

    // Update is called once per frame
    void Update () {
		
	}

}
