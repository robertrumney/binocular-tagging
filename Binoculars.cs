using UnityEngine;
using System.Collections.Generic;

public class Binoculars : MonoBehaviour
{
    [SerializeField] private List<GameObject> detectedEnemies = new List<GameObject>();
    [SerializeField] private float zoomFOV = 100f;

    private Camera mainCamera;
    private GameObject waypointCanvas;

    private void Awake()
    {
        waypointCanvas = GameObject.FindWithTag("WaypointCanvas");
    }

    private void Start()
    {
        mainCamera = GetComponent<Camera>();    
    }

    private void Update()
    {
        DetectEnemies();
    }

    private void DetectEnemies()
    {
        Vector3 origin = mainCamera.transform.position;
        Vector3 direction = mainCamera.transform.forward;

        RaycastHit[] hits = Physics.RaycastAll(origin, direction, 200);

        foreach (RaycastHit hit in hits)
        {
            GameObject enemyRoot = GetEnemyRootGameObject(hit.collider.gameObject);

            if (enemyRoot != null)
            {
                StateController stateController = enemyRoot.gameObject.GetComponent<StateController>();

                if (stateController != null)
                {
                    AddEnemyToList(stateController);
                }
            }
        }
    }

    private void AddEnemyToList(StateController stateController)
    {
        if (!detectedEnemies.Contains(stateController.gameObject))
        {
            detectedEnemies.Add(stateController.gameObject);

            if (stateController.binocularTag == null)
            {
                GameObject newWaypoint = Instantiate((GameObject)Resources.Load("Waypoint"));
                PointOfInterestMarker poim = newWaypoint.GetComponent<PointOfInterestMarker>();

                poim.TargetMarker = stateController.enemyAnimation.anim.GetBoneTransform(HumanBodyBones.Spine);
                poim.PlayerPosition = Game.instance.player.transform;

                poim.transform.parent = waypointCanvas.transform;
                poim.GetComponent<RectTransform>().localScale = Vector3.one;

                newWaypoint.SetActive(true);

                stateController.binocularTag = newWaypoint;

                Game.instance.Click();
            }
        }
    }

    private GameObject GetEnemyRootGameObject(GameObject gameObject)
    {
        Animator animator = gameObject.GetComponent<Animator>();

        if (animator != null)
        {
            return gameObject;
        }

        if (gameObject.transform.parent != null)
        {
            GameObject parent = gameObject.transform.parent.gameObject;

            while (parent.transform.parent != null && parent.GetComponent<Animator>() == null)
            {
                parent = parent.transform.parent.gameObject;
            }

            return parent;
        }
        else
        {
            return null;
        }
    }
}
