using UnityEngine;
using System.Collections;

public class EnemyPlaneTrigger : MonoBehaviour {

	EnemyPlaneController planeScript;

	// Use this for initialization
	void Start () {
		planeScript = GetComponentInParent<EnemyPlaneController> ();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Player")
		{
			planeScript.Activate ();
		}
	}
}
