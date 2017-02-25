using UnityEngine;
using System.Collections;

public class Ground : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Broom"))
        {
            Debug.Log("OUCH!!");
        }
    }

	// Update is called once per frame
	void Update () {
	
	}
}
