using UnityEngine;
using System.Collections;

public class CannonController : MonoBehaviour {
	
	GameObject target;
	Transform targetPos;
	bool aggro;
	Vector3 targetVector;
	public float turnSpeed;
	public GameObject bulletPrefab;
	public float bulletInterval;
	float bulletTimer = 0;
	
	
	// Use this for initialization
	void Start ()
	{
		aggro = false;
		turnSpeed = 5f;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(aggro == true)
		{
			targetVector = targetPos.position - transform.position; /*new Vector3(this.transform.position.x + targetPos.position.x, this.transform.position.y + targetPos.position.y,0f);*/
			targetVector.Normalize();
			float targetAngle = Mathf.Atan2(targetVector.y, targetVector.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.Slerp( transform.rotation, Quaternion.Euler( 0, 0, targetAngle -90f ), turnSpeed * Time.deltaTime );
			if(bulletTimer > bulletInterval)
			{
				Fire ();
				bulletTimer = 0f;
			}
			else
			{
				bulletTimer += Time.deltaTime;
			}
		}
		else if(aggro == false)
		{
			transform.rotation = Quaternion.Slerp( transform.rotation, Quaternion.Euler( 0, 0, 0 ), turnSpeed * Time.deltaTime );
		}
	}

	void OnTriggerEnter2D( Collider2D other )
	{
		if(other.tag == "Player")
		{
			aggro = true;
			target = GameObject.FindGameObjectWithTag(other.tag);
			targetPos = target.transform;
		}
	}
	
	void OnTriggerExit2D(Collider2D other)
	{
		if(other.tag == "Player")
		{
			aggro = false;
			target = null;
			targetPos = null;
			bulletTimer = 0f;
		}
	}
	
	void Fire()
	{
		Vector3 offset = targetPos.position - transform.position;
		offset.Normalize();
		Instantiate(bulletPrefab, this.transform.position + offset, this.transform.rotation);
	}
}
