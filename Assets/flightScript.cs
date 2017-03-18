using UnityEngine;
using System.Collections;

public class flightScript : MonoBehaviour {
    public Rigidbody rb;
    private SteamVR_TrackedController controller;
    private SteamVR_Controller.Device device;
    public Transform broom;
    private Transform BroomParent;
   public bool TouchingBroom = false;
    private BroomScript broomScript;
    public GameObject Wand;
    public GameObject Model;
    public GameObject Projectile;
    public GameObject TargetTip;
    public float ProjectileSpeed = 10;
    private float Stamina = 10;
    public float FireDelay = 0.5f;
    private float FireTimer = 0;
    [SerializeField]
    private bool WeaponDrawn=false;
    // Use this for initialization
    void Start () {
        //TargetTip = GetComponentInChildren<Transform>();
        controller = GetComponent<SteamVR_TrackedController>();
        controller.TriggerClicked += GrabBroom;
        controller.TriggerUnclicked += ReleaseBroom;
        BroomParent = broom.parent;
        broomScript = FindObjectOfType<BroomScript>();
        Wand.SetActive(WeaponDrawn);
        Model.SetActive(!WeaponDrawn);
    }
    void GrabBroom(object sender, ClickedEventArgs e)
    {
        if (WeaponDrawn && FireTimer>FireDelay && Stamina>0)
        {
            GameObject p=Instantiate(Projectile, TargetTip.transform.position, TargetTip.transform.rotation) as GameObject;
            Rigidbody PRB = p.GetComponent<Rigidbody>();
            PRB.AddForce(rb.velocity+PRB.transform.forward*ProjectileSpeed,ForceMode.Impulse);
            FireTimer = 0;
            --Stamina;
        }
        if (TouchingBroom)
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
        if (other.tag == "Broom")
            TouchingBroom = true;
       
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "FireBall")
        {
            Debug.Log("Hit with a fireball!");
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Broom")
            TouchingBroom = false;
      
    }
    float staminaRecharge = 0;
    void Update () {
        FireTimer += Time.deltaTime;
        staminaRecharge += Time.deltaTime;
        if(Stamina<10 && staminaRecharge>=2)
        {
            staminaRecharge = 0;
            ++Stamina;
        }
        device = SteamVR_Controller.Input((int)controller.controllerIndex);
        if(controller.padPressed)
        {
            Vector2 Touchpad;
            Touchpad = device.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0);
            if (Touchpad.y > 0)
            {
                WeaponDrawn = true;
                Wand.SetActive(WeaponDrawn);
                Model.SetActive(!WeaponDrawn);
            }
            else if (Touchpad.y <= 0)
            {
                WeaponDrawn = false;
                Wand.SetActive(WeaponDrawn);
                Model.SetActive(!WeaponDrawn);
            }
        }
       
        else if(controller.triggerPressed && TouchingBroom==true &&WeaponDrawn==false)
        {
            broom.transform.LookAt(transform);
            // broom.transform.rotation = gameObject.transform.rotation;
             if(controller.gripped && Stamina>0)
            {
                broomScript.SpeedMultiplier = 2;
                if(staminaRecharge==0)
                {
                    Stamina -= 2;
                }
            }
        }
        
        
	}
}
