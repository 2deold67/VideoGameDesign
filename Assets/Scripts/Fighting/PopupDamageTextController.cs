using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupDamageTextController : MonoBehaviour
{
    public static PopupDamageText popupText;
    private static GameObject canvas;
    public Resources popup;
    public GameObject text;
    public static void Initialize()
    {
         canvas = GameObject.Find("Canvas");
        if (!popupText)
        {
            popupText = Resources.Load<PopupDamageText>("Prefabs/PopupTextParent");
            print(popupText);
            Debug.Log("prefabLoaded");
        }
    }
    public static void CreatePopupDamage(string text, Transform location)
    {
       // popupText.transform.SetParent(canvas.transform, false);
        PopupDamageText instance = Instantiate(popupText);
        //PopupDamageText instance = Instantiate(popupText, new Vector3 (0, 0, 0), Quaternion.identity);
        Debug.Log("working");
        instance.transform.SetParent(canvas.transform, false);
        Debug.Log(text + "dmg");
        instance.SetText(text);
        


    }


}
