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
    
	void Start ()
    {
        
	}
	
	
	void Update ()
    {

	}

    private void OnMouseDown()
    {
        Taken = !Taken;
    }
}
