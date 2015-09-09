using UnityEngine;
using System.Collections;

public class OKbutton : MonoBehaviour
{
    void OnMouseDown()
    {
        Play();
    }
    void Play()
    {
        Application.LoadLevel("Menu");
    }
}