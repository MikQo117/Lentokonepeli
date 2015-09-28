using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MenuLogicScript : MonoBehaviour {

	public List<string> mapList;
	public string currentMap;

	// Use this for initialization
	void Start () {
		currentMap = "TrainingLevel";	
	}

	public void changeMap(int index)
	{
		currentMap = mapList [index];
	}
}