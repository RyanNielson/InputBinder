using UnityEngine;
using System.Collections;
using RyanNielson.InputBinder;

public class InputTester : MonoBehaviour {

    InputBinder inputBinder;

	// Use this for initialization
	void Start () 
    {
        inputBinder = GetComponent<InputBinder>();

        //inputBinder.BindAxis("Horizontal", Horizontal);
        //inputHandler.BindAxis("Vertical", Vertical);

        inputBinder.BindButton("Jump", InputEvent.Pressed, JumpPressed);
        //inputBinder.BindButton("Jump", InputButtonEvent.Released, JumpReleased);
        //inputHandler.BindButton("Jump", InputButtonEvent.Held, JumpHeld);
	}
	
    public void Horizontal(float value)
    {
        Debug.Log("Horizontal " + value);
    }

    public void Vertical(float value)
    {
        Debug.Log("Vertical " + value);
    }

    public void JumpPressed()
    {
        Debug.Log("Jump Pressed!!!");
    }

    public void JumpReleased()
    {
        Debug.Log("Jump Released!!!");
    }

    public void JumpHeld()
    {
        Debug.Log("Jump Held!!!");
    }
}
