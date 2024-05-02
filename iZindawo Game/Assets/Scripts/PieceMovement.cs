using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceMovement : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 startPosition;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Cast a ray from the camera to the mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // Create a RaycastHit variable to store information about the collision
            RaycastHit hit;

            // Check if the ray hits any colliders in the scene
            if (Physics.Raycast(ray, out hit))
            {
                // Check if the hit object is a circle piece
                if (hit.collider.CompareTag("Piece"))
                {
                    // Start dragging the piece
                    isDragging = true;
                    startPosition = hit.collider.transform.position;
                }
            }
        }

        if (isDragging)
        {
            // Calculate the position of the mouse in world space
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f; // Ensure the z-coordinate is 0 for 2D

            // Move the piece to the position of the mouse
            transform.position = mousePosition;

            // Clamp the position of the piece within the screen boundaries (if needed)
            // You can add clamping code here if you want to constrain the movement within the screen
        }

        if (Input.GetMouseButtonUp(0))
        {
            // Release the piece
            isDragging = false;

            // Snap the piece to the nearest grid position
            SnapToGrid();
        }
    }

    private void SnapToGrid()
    {
        // Get the nearest grid position based on the current position of the piece
        Vector3 nearestGridPosition = GetNearestGridPosition(transform.position);

        // Move the piece to the nearest grid position
        transform.position = nearestGridPosition;
    }

    private Vector3 GetNearestGridPosition(Vector3 position)
    {
        // Round the position to the nearest integer to get the grid coordinates
        int x = Mathf.RoundToInt(position.x);
        int y = Mathf.RoundToInt(position.y);

        // Return the nearest grid position
        return new Vector3(x, y, 0f);
    }
}