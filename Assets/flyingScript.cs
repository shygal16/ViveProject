using UnityEngine;
using System.Collections;

public class FlyingScript : MonoBehaviour
{
    public Rigidbody rb;

    public float Speed;
    // Use this for initialization
    void Start()
    {
     
    }
    void TriggerClickedFlyNow(object sender, ClickedEventArgs e)
    {
        Debug.Log(transform.rotation.eulerAngles.ToString());
        rb.AddForce(Speed * transform.forward);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
