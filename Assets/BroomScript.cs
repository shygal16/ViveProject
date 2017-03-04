using UnityEngine;
using System.Collections;

public class BroomScript : MonoBehaviour {
   public Transform CameraLocation;
    public Rigidbody rb;
    public float Speed=2000.0f;
    public float SpeedMultiplier=2.0f;
    public float offsetY = 10;
    public float offsetZ = 10;
    public float offsetX = 10;
    //public Transform Middle;

    // Use this for initialization
    void Awake () {
        // gameObject.transform.position = CameraLocation.position;
        CameraLocation = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }
	
	// Update is called once per frame
    
	void LateUpdate () {
        //transform.position = CameraLocation.position;
        Vector3 newpos=new Vector3(CameraLocation.position.x-offsetX,CameraLocation.position.y- offsetY, CameraLocation.position.z- offsetZ);
        gameObject.transform.position=newpos;
        rb.velocity = Speed*SpeedMultiplier * transform.forward;
        SpeedMultiplier = 1;
    }
    }
