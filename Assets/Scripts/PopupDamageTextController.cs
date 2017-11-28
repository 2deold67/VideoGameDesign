using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupDamageTextController : MonoBehaviour
{
    private static PopupDamageText popupText;

    public static void Initialize()
    {
        popupText = Resources.Load<PopupDamageText>("Prefabs/PopupTextParent");
    }
    public static void CreatePopupDamage(string text, Transform location)
    {

        PopupDamageText instance = Instantiate(popupText);

    }


}
