using UnityEngine;
using System.Collections;

public class LoadAdditive : MonoBehaviour {

	public string nextScene;

	// Use this for initialization
	void Start () {
		Application.LoadLevelAdditive (nextScene);
	}
}
