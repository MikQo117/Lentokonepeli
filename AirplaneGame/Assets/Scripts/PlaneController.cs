using UnityEngine;
using System.Collections;

public class PlaneController : MonoBehaviour
{

    public float maxForce;
    public float resistPerVelocity;
    public float forcePerSec;
    public float rotPerSec;
    public float maxSpeed;
    public float lift;
    float liftRatio;
    float throttleInput;
    float force;
    float yaw;
    bool inControl;
    bool throttleUp;
    bool throttleDown;
    bool yawUp;
    bool yawDown;

    Rigidbody2D rigidBody2D;

    // Use this for initialization
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Movement
        GetInput();
    }

    void FixedUpdate()
    {
        Move();
        rigidBody2D.AddForce(transform.up * 10);
        //Debug.Log("velocity: " + rigidBody2D.velocity.magnitude);
        //Debug.Log("force: " + force);
        //Debug.Log(rigidBody2D.rotation);
    }

    void GetInput()
    {
        //Get throttle
        throttleInput = Input.GetAxis("Throttle");
        if (throttleInput > 0)
        {
            throttleUp = true;
        }
        else if (throttleInput < 0)
        {
            throttleDown = true;
        }
        else if (throttleInput == 0)
        {
            throttleUp = false;
            throttleDown = false;
        }
        //Get yaw
        yaw = Input.GetAxis("Yaw");

        if (yaw > 0)
        {
            yawUp = true;
        }
        else if (yaw < 0)
        {
            yawDown = true;
        }
        else if (yaw == 0)
        {
            yawUp = false;
            yawDown = false;
        }
    }

    void Move()
    {
        //Force
        if (throttleUp)
        {
            force += forcePerSec * Time.deltaTime;
            if (force > maxForce)
            {
                force = maxForce;
            }
        }
        else if (throttleDown)
        {
            force -= forcePerSec * Time.deltaTime;
            if (force < 0f)
            {
                force = 0f;
            }
        }

        //Rotation
        if (yawUp)
        {
            //rigidBody2D.rotation += rotPerSec * Time.deltaTime;
            rigidBody2D.AddTorque(rotPerSec * Time.deltaTime, ForceMode2D.Impulse);
        }
        else if (yawDown)
        {
            //rigidBody2D.rotation -= rotPerSec * Time.deltaTime;
            rigidBody2D.AddTorque(-rotPerSec * Time.deltaTime, ForceMode2D.Impulse);
        }

        /*if(rigidBody2D.velocity.magnitude > maxSpeed)
        {
            Vector2 newSpeed = rigidBody2D.velocity;
            newSpeed.Normalize();
            newSpeed = newSpeed * maxSpeed;
            rigidBody2D.velocity = newSpeed;
        }*/

        //Forward force
        if (force > 0)
        {
            rigidBody2D.AddForce(transform.right * force);
        }
        //Air resistance
        Vector2 resistVector = -rigidBody2D.velocity;
        resistVector.Normalize();
        rigidBody2D.AddForce(resistVector * (resistPerVelocity * rigidBody2D.velocity.magnitude));
        //Lift
        if (rigidBody2D.velocity.magnitude != 0)
        {
            liftRatio = Mathf.Abs((rigidBody2D.velocity.x / rigidBody2D.velocity.magnitude) * (rigidBody2D.velocity.magnitude / maxSpeed));
            Debug.Log(liftRatio);
            rigidBody2D.AddForce(transform.up * (lift * liftRatio));
        }
    }
}