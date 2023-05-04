# Unity Binoculars Shader and Screen Effect

This project provides an example of how to implement a binoculars shader and screen effect in Unity. The shader simulates the effect of viewing the screen through binoculars, with adjustable zoom and distortion parameters. The screen effect applies the shader to the camera's output using the Unity Post-Processing stack.

This code is loosely based on Robert Rumney's binocular system, and is provided as an educational resource only.

## Usage

To update the binoculars zoom, use the `Update` method in your binoculars script, as shown in the included `EquipBinoculars.cs` script:

```csharp
private void Update()
{
    float y = Input.mouseScrollDelta.y;

    currentFOV -= y;
    currentFOV = Mathf.Clamp(currentFOV, -54, baseFOV);

    Game.instance.playerScript.PlayerWeaponsComponent.IronsightsComponent.fovMod = currentFOV;

    if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(Game.instance.settings.controls.inventory))
    {
        Destroy(this);
    }
}
```
The `currentFOV` variable represents the current binoculars zoom, and is used to adjust the field of view in the `IronsightsComponent` of the player's weapons. The binoculars script should be active while this method is being called.

## Credits

This code is based on Robert Rumney's binocular system. The example shader and screen effect were developed by ChatGPT.

## License

This code is provided under the MIT License. See the `LICENSE` file for details.

## Example

For a demonstration of the binoculars effect in action, visit [this YouTube video](https://www.youtube.com/watch?v=ipj4iGDMAmM)
