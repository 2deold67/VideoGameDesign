using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class PopupDamageText : MonoBehaviour
{

    public Animator animator;
    private Text damageText;

    void Start()
    {
        AnimatorClipInfo[] clipInfo = animator.GetCurrentAnimatorClipInfo(0);
        Destroy(gameObject, clipInfo[0].clip.length);

        damageText = animator.GetComponent<Text>();


    }



    public void SetText(string text)
    {
        Debug.Log(animator.GetComponent<Text>().text);
        animator.GetComponent<Text>().text = text;
        //damageText.text = text;


    }







}


