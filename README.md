# Binoculars

Binoculars is a script for Unity that allows the player to detect enemies in their view using a pair of binoculars. The script uses raycasting to detect enemies within the player's view, and then checks if the detected enemy has an Enemy AI `StateController` component attached to it. If so, the enemy is added to a list and a waypoint is created to track the enemy's position.

Please note that this script is not designed to work directly out of the box. You will need to implement the Enemy AI `StateController` component and the shader/effect for the binoculars yourself. However, a waypoint script is provided.

## How to Use

1. Attach the `Binoculars` script to a camera object in your Unity project.
2. Create an `Empty` object in your scene and give it a tag of "WaypointCanvas".
3. Attach the `PointOfInterestMarker` script to a waypoint object and modify it to suit your needs.
4. Create an `Enemy AI` object with a `StateController` component attached to it.
5. Attach a shader/effect to the binoculars object that allows the player to zoom in on enemies.
6. Modify the `Binoculars` script to suit your needs.

## Modifying the Script

The `Binoculars` script is designed to be easily modifiable. Here are some possible modifications you might want to make:

- Change the list of detected enemies to use a dictionary or hashset.
- Modify the waypoint creation to use a different prefab or to add additional components to the waypoint.
- Change the field of view when zooming in on enemies.
- Modify the way enemies are detected or the way the script interacts with the `StateController` component.
- Change the way the binoculars effect is implemented.

## Credits

The `Binoculars` script was written by Robert Rumney and is released under the MIT License. 

The `PointOfInterestMarker` script was adapted from a script provided by Unity Technologies and is also released under the MIT License.
