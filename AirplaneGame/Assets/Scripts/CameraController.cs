using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	GameObject player;
	PlayerController playerController;
	Vector3 playerPos;
	Vector3 playerDir;
	Vector3 oldPos;
	Vector3 angleVector = new Vector3(1f,0f,0f);
	public float playerSpace = 0.20f;
	float viewportWidth;
	float viewportHeight;
	float playerAngle;
	float relativeHeight;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("kone2");
		playerController = player.GetComponent<PlayerController>();
		viewportWidth = (float)(Camera.main.orthographicSize * 2.0 * Screen.width / Screen.height);
		viewportHeight = (float)(Camera.main.orthographicSize * Screen.width / Screen.height);
	}
	
	// Update is called once per frame
	void Update () {
		playerPos = player.transform.position;
		oldPos = transform.position;
		Vector3 newX = new Vector3 (AdjustXPos(), 0f, -10f);
		this.transform.position = newX;
		this.transform.position += Vector3.Lerp (new Vector3 (0f, oldPos.y, -10f), new Vector3 (0f, AdjustYPos (), -10f), Time.deltaTime);

		/*Debug.Log ("PlayerY: " + playerPos.y);
		Debug.Log("CameraY: " + transform.position.y); IT WORKES*/

		if (transform.position.y - playerPos.y > viewportHeight / 3)
		{
			transform.position = new Vector3(transform.position.x, playerPos.y + viewportHeight/3,-10f);
		}
		else if(transform.position.y - playerPos.y < -(viewportHeight / 3))
		{
			transform.position = new Vector3(transform.position.x, playerPos.y - viewportHeight/3,-10f);
		}
	}

	float AdjustXPos()
	{
		float xPos = playerPos.x + viewportWidth * playerSpace;
		return xPos;
	}

	float AdjustYPos()
	{
		float yPos = 0f;
		playerDir = playerController.direction;
		playerAngle = Vector3.Angle (angleVector, playerDir);
		if(playerAngle > 45)
		{
			playerAngle = 45f;
		}
		relativeHeight = playerAngle / 45f;
		if(playerDir.y > 0)
		{
			yPos = playerPos.y + (viewportHeight/3) * relativeHeight;
		}
		else if(playerDir.y < 0)
		{
			yPos = playerPos.y - (viewportHeight/3) * relativeHeight;
		}
		return yPos;
	}
}






























