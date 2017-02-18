using UnityEngine;
using System.Collections;

public class flightScript : MonoBehaviour {
    public Rigidbody rb;
    private SteamVR_TrackedController controller;
    public float Speed;
    public Transform broom;
    private Transform BroomParent;
   public bool TouchingBroom = false;
    // Use this for initialization
    void Start () {
        controller = GetComponent<SteamVR_TrackedController>();
        controller.TriggerClicked += GrabBroom;
        controller.TriggerUnclicked += ReleaseBroom;
        BroomParent = broom.parent;
    }
    void GrabBroom(object sender, ClickedEventArgs e)
    {
        if(TouchingBroom)
        {

            // rb.velocity=Speed * transform.forward;
            // broom.localRotation = transform.localRotation;
            //broom.parent = gameObject.transform;
        }
    }
    void ReleaseBroom(object sender, ClickedEventArgs e)
    {
        //rb.velocity = Vector3.zero;
       // broom.parent = BroomParent;
    }
    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Broom")
       TouchingBroom = true;
        
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Broom")
            TouchingBroom = false;
      
    }
    void Update () {
            rb.velocity = Speed * broom.forward;
        if(controller.triggerPressed && TouchingBroom==true)
        {
            broom.transform.LookAt(transform);
            // broom.transform.rotation = gameObject.transform.rotation;
        }
       
	}
}
