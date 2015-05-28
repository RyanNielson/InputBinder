# InputBinder

InputBinder makes it easy for components to respond to axis, button, and key input events. Bind game inputs to methods via code or using the inspector to add event driven input handling to your project.

This is somewhat based on Unreal Engine 4's [InputComponent](https://docs.unrealengine.com/latest/INT/API/Runtime/Engine/Components/UInputComponent/index.html).

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

### Via Scripts

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
        
        inputBinder.BindButton(KeyCode.Space, InputEvent.Pressed, JumpPressed);
        inputBinder.BindButton(KeyCode.Space, InputEvent.Released, JumpReleased);
        inputBinder.BindButton(KeyCode.Space, InputEvent.Held, JumpHeld);
    }
	
    public void Horizontal(float value)
    {
        // Use Horizontal axis value here.
    }

    public void Vertical(float value)
    {
        // Use Vertical axis value here.
    }

    public void JumpPressed()
    {
       	// Respond to Jump or space key input pressed.
    }

    public void JumpReleased()
    {
        // Respond to Jump or space key input released.
    }

    public void JumpHeld()
    {
        // Respond to Jump or space key input held.
    }
}
```

## Via Inspector

Using InputBinder via the inspector makes it quite easy to set up input bindings. All that is required is to add an element to either the Axis Bindings, Button Bindings, or Key Bindings list. Once added, each type of binding has its own options.

#### Axis Bindings

Select the axis name that was set up in Unity's input manager, and then use the Bound Event selector to choose objects and methods to bind to the axis. The chosen methods must accept a single float argument.

#### Button Bindings

Select the button name that was set up in Unity's input manager, input event, and then use the Bound Event selector to choose objects and methods to bind to the button.

##### Key Bindings

Select the key, input event, and then use the Bound Event selector to choose objects and methods to bind to the button.
