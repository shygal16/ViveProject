using UnityEngine;
using System.Collections;

public class FireballScript : MonoBehaviour {
    float Lifetime = 3;
    float timer = 0;
    [SerializeField]
    float Speed=5;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if(timer>Lifetime)
        {
            Destroy(this.gameObject);
        }
	}
}
