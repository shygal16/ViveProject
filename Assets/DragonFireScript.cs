using UnityEngine;
using System.Collections;

public class DragonFireScript : MonoBehaviour {
    
    public Rigidbody rb;

    public GameObject Projectile;
    public GameObject TargetTip;
    public float ProjectileSpeed = 10;
    public float Firedelay=0.5f;
    private float FireTimer=0;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        FireTimer+= Time.deltaTime;

        if (Input.GetKey(KeyCode.Space) && FireTimer> Firedelay)
        {
            GameObject p = Instantiate(Projectile, TargetTip.transform.position, TargetTip.transform.rotation) as GameObject;
            Rigidbody PRB = p.GetComponent<Rigidbody>();
            PRB.AddForce(rb.velocity + PRB.transform.forward * ProjectileSpeed, ForceMode.VelocityChange);
            FireTimer = 0;
        }

    }
}
