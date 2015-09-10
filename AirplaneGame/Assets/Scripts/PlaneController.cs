using UnityEngine;
using System.Collections;

public class PlaneController : MonoBehaviour {

    public float maxForce;
    float maxNegForce;
    float lift;
    float throttle;
    public float throttleDeadZone;
    float yaw;
    bool inControl;
    Rigidbody2D rigidBody2D;

	// Use this for initialization
	void Start ()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Movement
        GetInput();
        Move();
        rigidBody2D.AddForce(transform.up * 10);
    }

    void GetInput()
    {
        //Get throttle
        throttle = Input.GetAxis("Throttle");
        //Get yaw
        yaw = Input.GetAxis("Yaw");
    }

    void Move()
    {
        if (throttle > throttleDeadZone || throttle < -throttleDeadZone)
        {
            rigidBody2D.AddForce(transform.right * (throttle * maxForce));
            
        }
        
        Debug.Log(throttle);
    }
}