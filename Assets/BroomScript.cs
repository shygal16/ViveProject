using UnityEngine;
using System.Collections;

public class BroomScript : MonoBehaviour {
   public Transform start;
    public float offset = 10;
   //public Transform Middle;

	// Use this for initialization
	void Awake () {
        start = GameObject.FindGameObjectWithTag("MainCamera").transform;
        start.position.Set(start.position.x, start.position.y- offset, start.position.z-8);
        transform.position = start.position;
	}
	
	// Update is called once per frame
    
	void Update () {
        transform.position = start.position;
    }
    }
