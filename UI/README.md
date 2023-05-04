# Point Of Interest Marker

This is a Unity script for a point of interest marker that displays an arrow pointing to a target position on the screen, along with a distance text. It has been adapted from a script by Unity Technologies with optimizations and additional features, and can be used as a supplement to the binoculars script it comes with.

## Features

- Displays an arrow pointing to a target position on the screen
- Shows a distance text when the target is on screen
- Fades the marker in and out when activated or deactivated
- Uses a StringBuilder instead of assigning directly to the string to avoid memory allocation

## Usage

Attach the `PointOfInterestMarker` script to a game object with an Image component. Set the `TargetMarker` and `PlayerPosition` fields to the respective transforms. Set the `ArrowSprite` and `OnScreenSprite` fields to the arrow and on-screen sprites, respectively. Set the `DistanceText` field to the text component to display the distance. Set the `BoundaryRect` field to the screen area where the marker is allowed to appear.

The script can be activated and deactivated using the `Activate()` and `Deactivate()` methods. It also has a `SetSprite()` method to change the sprite of the marker.

## Optimization

This script uses a StringBuilder to format the distance text instead of assigning directly to the string to avoid memory allocation. This is important for performance since string operations can create a lot of garbage for the garbage collector (GC) to collect, which can cause frame rate spikes and stuttering. By using a StringBuilder instead, the script avoids creating new string objects every frame, reducing the load on the GC and improving performance.

## Adaptation

This script has been adapted from a script by Unity Technologies and includes additional features and optimizations. It can be used as a supplement to the binoculars script developed by [Robert Rumney](https://github.com/robertrumney)
