using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingPosition : MonoBehaviour
{
    void Start()
    {
        // Get the position of the starting position GameObject
        Vector3 startPosition = transform.position;

        // Convert the position to grid coordinates
        int gridX = Mathf.RoundToInt(startPosition.x);
        int gridY = Mathf.RoundToInt(startPosition.y);

        // Find the grid box sprite collider at the extracted coordinates
        GameObject gridObject = GameObject.Find($"P({gridX},{gridY})");
        if (gridObject != null)
        {
            // Get the center of the grid box sprite collider
            Vector3 gridPosition = gridObject.transform.position;

            // Set the position of the starting position GameObject to the center of the grid box collider
            transform.position = gridPosition;
        }
        else
        {
            Debug.LogError($"Grid object P({gridX},{gridY}) not found!");
        }
    }
}
