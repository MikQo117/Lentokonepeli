using UnityEngine;
using System.Collections;

public class MissileController : MonoBehaviour {

	Vector3 direction;
	Vector3 currentDirection;
	Vector3 newDirection;
	public float speed;
	public float timeAlive = 5f;
	Transform targetPos;
	GameObject target;
	float aliveTimer;

	// Use this for initialization
	void Start () 
	{
		targetPos = GameObject.FindObjectOfType<GameLogic> ().player.transform;
		target = GameObject.FindObjectOfType<GameLogic> ().player;
		//direction =  transform.rotation * Vector3.up;
		//currentDirection = direction;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(aliveTimer >= timeAlive)
		{
			Destroy(gameObject);
		}
		else
		{
			aliveTimer += Time.deltaTime;
		}
		newDirection = targetPos.position - transform.position;
		newDirection.Normalize ();
		currentDirection.Normalize();
		transform.position += newDirection * speed * Time.deltaTime;
		transform.rotation = Quaternion.FromToRotation (currentDirection, newDirection);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		KillTarget ();
		Die ();
	}

	void KillTarget()
	{
		target.GetComponent<PlayerController>().Die ();
	}

	void Die()
	{
		Destroy (this.gameObject);
	}
}