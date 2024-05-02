using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//public class PieceMovementTest : MonoBehaviour

//{
//public LayerMask pieceLayerMask; // Layer mask for the "Piece" layer
// public LayerMask gridLayerMask; // Layer mask for the "Grid" layer

// private GameObject selectedPiece; // Currently selected piece
//private bool isDragging = false; // Flag to track if the piece is being dragged

//private void Update()
//{
// Check if the left mouse button is pressed
// if (Input.GetMouseButtonDown(0))
// {
// Cast a ray from the mouse position
//   Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
// RaycastHit hit;

// Check if the ray hits an object on the "Piece" layer
// if (Physics.Raycast(ray, out hit, Mathf.Infinity, pieceLayerMask))
// {
// Get the GameObject that was hit
// selectedPiece = hit.collider.gameObject;
// isDragging = true; // Start dragging the piece
// }
// }

// If the piece is being dragged
//  if (isDragging)
// {
//   // Update the position of the piece based on mouse movement
//   Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
//   mousePosition.z = 0; // Ensure the z-coordinate is zero for 2D
//   selectedPiece.transform.position = mousePosition;
//}

// Check if the left mouse button is released
// if (Input.GetMouseButtonUp(0) && isDragging)
// {
//     isDragging = false; // Stop dragging
//     // Move the piece to the center of the grid object below it
//     MovePieceToCenterOfGridBelow(selectedPiece);
// }
//    }

//  private void MovePieceToCenterOfGridBelow(GameObject piece)
//  {
//      // Cast a ray from the piece's position downward to find the grid
//      RaycastHit hit;
//      if (Physics.Raycast(piece.transform.position, Vector3.down, out hit, Mathf.Infinity, gridLayerMask))
//      {
//          // Get the center of the grid object below the piece
//          Vector3 center = hit.collider.bounds.center;
//
//           // Move the piece to the center of the grid object
//           piece.transform.position = center;
//       }
//       else
//       {
//           Debug.LogWarning("No grid found under the selected piece.");
//       }
//   }
//}




//public class ClickAndDragSelectedMovement : MonoBehaviour
//{
// public LayerMask obstacleMask; // Define the layers that represent obstacles
//
//    private bool isDragging = false;
//    private Vector2 offset;
//    private Transform selectedPiece;

//   void Update()
//  {
//    // Check for mouse button down to start dragging
//  if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
//{
//       StartDragging();
//     }

// Check for mouse button release to stop dragging
//   if (Input.GetMouseButtonUp(0))
//  {
//           StopDragging();
// }

// If dragging, move the object with the mouse
// if (isDragging)
//{
//   MoveObjectWithMouse();
//        }
//    }
//
//    void StartDragging()
//    {
// Cast a ray from the mouse position
//        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
//        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, Mathf.Infinity, obstacleMask);
//
//       // If the ray hits something and it's a selected piece, start dragging
//        if (hit.collider != null && hit.collider.CompareTag("Piece") && hit.transform == selectedPiece)
//        {
//            isDragging = true;
//            offset = (Vector2)selectedPiece.position - hit.point;
//        }
//    }
/////
//    void StopDragging()
//   {
//        isDragging = false;
//    }
//
//   void MoveObjectWithMouse()
//   {
//       // Get the target position based on the mouse position
//       Vector2 targetPosition = (Vector2)(Camera.main.ScreenToWorldPoint(Input.mousePosition)) + offset;
//
//       // Move the selected piece to the target position
//       selectedPiece.position = targetPosition;
//    }
//
//    // Set the selected piece
//    public void SetSelectedPiece(Transform piece)
//    {
//        selectedPiece = piece;
//    }
//}



public class PieceMovementTest : MonoBehaviour
{
    // Reference to the GridOccupancyChecker script
    public GridOccupancy gridOccupancyChecker;

    // Movement speed of the piece
    public float moveSpeed = 5f;

    // Target position for the piece to move towards
    private Vector3 targetPosition;

    // Flag to indicate if the piece is currently selected
    private bool isSelected = false;

    // Update is called once per frame
    void Update()
    {
        // Check if the piece is selected
        if (isSelected)
        {
            // Move the piece only if it's selected
            MovePiece();
        }
    }

    // Function to move the piece towards the target position
    private void MovePiece()
    {
        // Check for mouse input to set the target position
        if (Input.GetMouseButton(0))
        {
            // Calculate the target position based on mouse click
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPosition.z = 0f; // Ensure z position is 0 (2D)

            // Cast a ray from the piece's position in the direction of the target position
            RaycastHit2D hit = Physics2D.Raycast(transform.position, targetPosition - transform.position, 1f, LayerMask.GetMask("GridCell"));

            // Check if the ray hit a grid cell
            if (hit.collider != null)
            {
                // Get the grid position of the hit cell
                int gridPos = gridOccupancyChecker.WorldToGridPosition(hit.point);

                // Check if the grid cell is occupied
                if (!gridOccupancyChecker.IsGridPositionOccupied(gridPos))
                {
                    // Move the piece towards the target position
                    transform.position = Vector3.MoveTowards(transform.position, hit.point, moveSpeed * Time.deltaTime);

                    // Check if the piece has reached the target position
                    if (Vector3.Distance(transform.position, hit.point) < 0.1f)
                    {
                        // Snap the piece to the target position
                        transform.position = hit.point;
                    }
                }
                else
                {
                    // If the grid cell is occupied, snap the piece back to its previous position
                    transform.position = Vector3.MoveTowards(transform.position, targetPosition, -moveSpeed * Time.deltaTime);
                }
            }
            else
            {
                // If the ray didn't hit a grid cell, snap the piece back to its previous position
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, -moveSpeed * Time.deltaTime);
            }
        }
    }

    // Function to set the piece as selected
    public void SetSelected(bool selected)
    {
        isSelected = selected;
    }
}


