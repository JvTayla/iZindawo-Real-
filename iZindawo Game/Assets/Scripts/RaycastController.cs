using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RayCast : MonoBehaviour
{
    private GameObject selectedPiece;
    private Color originalColor;
    public LayerMask layersToHit;
    void Update()
    {
        // Check if the left mouse button is pressed
        if (Input.GetMouseButtonDown(0))
        {
           
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Check if the ray hits any colliders in the scene
            if (Physics.Raycast(ray, out hit))
            {
                // Get the GameObject that was hit
                GameObject hitObject = hit.collider.gameObject;

                // Perform actions based on the hit object
                Debug.Log("Hit object: " + hitObject.name);

                // Check if the hit object is a game piece
                if (hitObject.CompareTag("Piece"))
                {
                    // If a piece was already selected, deselect it
                    if (selectedPiece != null)
                    {
                        // Restore the original color of the previously selected piece
                        Renderer prevRenderer = selectedPiece.GetComponent<Renderer>();
                        prevRenderer.material.color = originalColor;
                    }

                    // Select the new piece
                    selectedPiece = hitObject;

                    // Store the original color of the selected piece
                    Renderer renderer = selectedPiece.GetComponent<Renderer>();
                    originalColor = renderer.material.color;

                    // Apply a white overlay to the selected piece
                    renderer.material.color = Color.Lerp(originalColor, Color.white, 0.5f); // Adjust the last parameter to control the strength of the overlay
                }
                else if (selectedPiece != null && hitObject.name.StartsWith("P("))
                {
                    // Check if the grid position is empty (i.e., not occupied by another piece)
                    if (!IsGridPositionOccupied(hitObject))
                    {
                        // Move the selected piece to the center of the grid position
                        Vector3 newPosition = hitObject.transform.position;
                        selectedPiece.transform.position = newPosition;

                        // Restore the original color of the selected piece
                        Renderer prevRenderer = selectedPiece.GetComponent<Renderer>();
                        prevRenderer.material.color = originalColor;

                        // Deselect the piece after moving it
                        selectedPiece = null;
                    }
                    else
                    {
                        Debug.Log("Cannot move to occupied grid position!");
                    }
                }
            }
        }
    }

    // Helper method to check if a grid position is occupied by another piece
    private bool IsGridPositionOccupied(GameObject gridPosition)
    {
        // Check if there is a piece tagged "Piece" at the specified grid position
        Collider[] colliders = Physics.OverlapBox(gridPosition.transform.position, Vector3.one * 0.5f);
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Piece"))
            {
                return true; // Grid position is occupied
            }
        }
        return false; // Grid position is empty
    }
}



