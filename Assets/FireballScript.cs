using UnityEngine;
using System.Collections;

public class FireballScript : MonoBehaviour {
    float Lifetime = 3;
    float timer = 0;
    Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update () {
       // rb.velocity = Vector3.forward*10;
        timer += Time.deltaTime;
        if(timer>Lifetime)
        {
            Destroy(this.gameObject);
        }
	}
    void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
    }
}
