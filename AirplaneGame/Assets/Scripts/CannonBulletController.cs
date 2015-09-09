using UnityEngine;
using System.Collections;

public class CannonBulletController : MonoBehaviour {
	
	Vector3 direction;
	public float speed;
	public float timeAlive = 5f;
	float aliveTimer;

	// Use this for initialization
	void Start ()
	{
		direction = this.transform.rotation * Vector3.up;
		//aliveTimer = 0f;
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
		this.transform.position += direction * speed * Time.deltaTime;
	}
}