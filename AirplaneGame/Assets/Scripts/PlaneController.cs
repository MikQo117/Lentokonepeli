using UnityEngine;
using System.Collections;

public class PlaneController : MonoBehaviour {

    float maxForce;
    float maxNegForce;
    float lift;
    float throttle;

	// Use this for initialization
	void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    void GetInput()
    {
        //Get throttle
        throttle = Input.GetAxis("Throttle");
        //Get Yaw

    }
}