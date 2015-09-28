using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour {

	public Vector3 direction;
	float speed;
	float maxSpeed = 20f;
	float minSpeed = 0f;
	float lift = 3f;
	float acceleration;
	float mass;
	float turnRate = 5f;
	float gravity = 9f;
	float liftPerSpeed = 1f / 3f;
	float maxLift = 3f;
	string playerState;
	//public enum playerState {Alive, Dead};

	// Use this for initialization
	void Start () {
		direction = Vector3.right;
		speed = 5f;
		acceleration = 11f;
		mass = 400f;
		playerState = "alive";
	}
	
	// Update is called once per frame
	void Update () {

		if(playerState == "alive")
		{
			this.transform.position -= new Vector3(0f,gravity * Time.deltaTime,0f);

			if( Input.GetButton("ThrottleUp")){
				if(speed > maxSpeed)
				{
					speed = maxSpeed;
				}
				else
				{
					speed += acceleration * Time.deltaTime;
				}
			}
			else if(Input.GetButton("ThrottleDown")){
				if(speed < minSpeed)
				{
					speed = minSpeed;
				}
				else
				{
					speed -= acceleration * Time.deltaTime;
				}
			}
			else if(Input.GetButton("TurnUp")){
				direction = Quaternion.Euler(0f,0f,turnRate)* direction;
				transform.Rotate(new Vector3(0f,0f,1f),turnRate);
			}
			else if(Input.GetButton("TurnDown")){
				direction = Quaternion.Euler(0f,0f,-turnRate)* direction;
				transform.Rotate(new Vector3(0f,0f,1f),-turnRate);
			}

			//Debug.Log (this.transform.rotation);
			lift = speed * liftPerSpeed * Time.deltaTime;
			if(lift >= maxLift)
			{
				lift = maxLift;
			}
			Vector3 currentPosition = transform.position;
			transform.position += direction * speed * Time.deltaTime;
			transform.position += new Vector3 (0f, lift);
		}
	}

	void OnTriggerEnter2D( Collider2D other )
	{
		if( other.tag == "Collideables")
		{
			Die ();
			//Crash, boom!
		}
		else if(other.tag == "Runway")
		{

		}
	}

	public void Die()
	{
		//Play death animation, set gameState to lose etc.
		playerState = "dead";
		speed = 0;
	}
}









































