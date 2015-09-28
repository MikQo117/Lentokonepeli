using UnityEngine;
using System.Collections;

public class EnemyPlaneController : MonoBehaviour {

	float speed;
	Vector3 direction;
	bool active;

	// Use this for initialization
	void Start () {
		speed = 10f;
		direction = new Vector3 (-1f, 0f, 0f);
		active = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(active == true)
		{
			transform.position += direction * speed * Time.deltaTime; 
		}
	}

	public void Activate()
	{
		active = true;
	}
}
