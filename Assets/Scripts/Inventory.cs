using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    public List<GameObject> FurnitureIcons;
    public GameObject InventoryPanel;
    public GameObject SelectedFurniture;
    public int SelectedIcon;
    public GameObject CancelButton;
    // Use this for initialization
    void Start ()
    {
        SortIcons();
	}

    private void SortIcons()
    {
        float leftColumn = -50,
              rightColumn = 50;
        int rowCount = 0;

        GameObject[] oldIcons = GameObject.FindGameObjectsWithTag("Icon");
        if (oldIcons.Length > 0)
        {
            for (int i = 0; i < oldIcons.Length; i++)
            {
                Destroy(oldIcons[i]);
            }
        }

        for (int i = 0; i < FurnitureIcons.Count; i++)
        {
            GameObject temp = Instantiate(FurnitureIcons[i], InventoryPanel.transform);
            temp.GetComponent<FurnitureIcon>().RefNum = i;
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

    internal void SelectIcon(int icon)
    {
        SelectedIcon = icon;
    }

    public void RemoveSelectedIcon()
    {
        FurnitureIcons.RemoveAt(SelectedIcon);
        SortIcons();
        SelectedIcon = -1;
    }

    public void Cancel()
    {
        DestroyObject(SelectedFurniture);
        SelectedIcon = -1;
    }

    private bool IsOdd(int value)
    {
        return value % 2 != 0;
    }

    // Update is called once per frame
    void Update ()
    {
        if (CancelButton.activeSelf != (SelectedIcon != -1))
        {
            CancelButton.SetActive(SelectedIcon != -1);
        }	
	}

}
