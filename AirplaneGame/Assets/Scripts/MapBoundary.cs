using UnityEngine;
using System.Collections;

public class MapBoundary : MonoBehaviour {

	GameLogic gl;

	void Start()
	{
		gl = GameObject.Find ("GameLogic").GetComponent<GameLogic> ();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		//Out of bounds
		gl.playerOutOfBounds = true;
		Debug.Log ("OOB trigger");
		gl.player.GetComponent<PlayerController> ().Die ();
	}
}
