# InputBinder

InputBinder makes it easy for components to respond to axis, button, and key input events. InputBinder links the project inputs to script methods via code or the inspector.

## Methods
```cs 
BindAxis(string name, UnityAction<float> action)
```
Binds an given axis name to a method that has a single float argument. This method will be called every `Update` with the value of the axis.

```cs 
BindButton(string name, InputEvent inputEvent, UnityAction action)
```
Binds an given button name and `InputEvent` type to a method that has no arguments. This method will only be called when the provided input event occurs for the given input name.

```cs 
BindKey(KeyCode key, InputEvent inputEvent, UnityAction action)
```
Binds an given `KeyCode` and `InputEvent` type to a method that has no arguments. This method will only be called when the provided input event occurs for the given key.

## Usage

To begin using InputBinder you need to add the InputBinder component to a GameObject. Once added, the inspector allows you to bind input via the inspector using UnityEvents, or you can create bindings in code. Both methods will be explained, and assume you're working with a GameObject with an InputBinder component.

#### Via Scripts

```cs
using UnityEngine;
using System.Collections;
using RyanNielson.InputBinder;

public class InputBinderTester : MonoBehaviour 
{
    InputBinder inputBinder;

    void Start () 
    {
        inputBinder = GetComponent<InputBinder>();

        inputBinder.BindAxis("Horizontal", Horizontal);
        inputBinder.BindAxis("Vertical", Vertical);

        inputBinder.BindButton("Jump", InputEvent.Pressed, JumpPressed);
        inputBinder.BindButton("Jump", InputEvent.Released, JumpReleased);
        inputBinder.BindButton("Jump", InputEvent.Held, JumpHeld);
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
```

#### Via Inspector
