using UnityEngine;
using System.Collections;

public class GoToSceneButton : MonoBehaviour {

	public string sceneTo;

	// Use this for initialization
	void Start ()
	{
		
	}

	void OnMouseDown()
	{
		Application.LoadLevel (sceneTo);
	}
}
