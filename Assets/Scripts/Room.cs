using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{

    // Use this for initialization

    public Vector2 Dimensions;
    public bool[,] segments;
    public GameObject SegmentGO;
	void Start ()
    {
        float segmentX = SegmentGO.GetComponent<Renderer>().bounds.size.x;
        float segmentZ = SegmentGO.GetComponent<Renderer>().bounds.size.z;
        segments = new bool[(int)Dimensions.x, (int)Dimensions.y];
        for (int i = 0; i < segments.GetLength(0); i++)
        {
            for (int j = 0; j < segments.GetLength(1); j++)
            {
                segments[i, j] = false;
                Instantiate(SegmentGO, new Vector3(segmentX * i, 0, segmentZ * j),transform.rotation,transform).GetComponent<Segment>().Taken = segments[i, j];
            }
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
