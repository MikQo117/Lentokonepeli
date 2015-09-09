using UnityEngine;
using System.Collections;

public class Playbutton : MonoBehaviour
{
	public string nextScene;

    void OnMouseDown()
    {
        Play();
    }
    void Play()
    {
        Application.LoadLevel(nextScene);
    }
}