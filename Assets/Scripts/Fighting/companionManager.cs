using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class companionManager : MonoBehaviour {

    public float damage;
    public float strength;
    public float hitChance;
    public int energy;
    public int level;

	// Use this for initialization
	void Start ()
    {
        strength = 5.0f;
        level = 1;
        hitChance = 0.3f;
        energy = 3;
        damage = strength * level;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public bool TryHit()
    {
       float  i = Random.Range(0.0f, 1.0f);
        if (i <= 0.3f)
        {
            return true;
            Debug.Log("companionManager hits!");
        }
        else
        {
            return false;
        }
    }
}
