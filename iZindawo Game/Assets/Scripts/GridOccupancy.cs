using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridOccupancy : MonoBehaviour
{ 
    // Reference to the GridHandler script
   
    public GridManager gridManager;

    // Array to store occupancy status of each grid cell
    private bool[] isOccupied;

    void Start()
    {
        // Ensure the GridHandler script reference is set
        if (gridManager == null)
        {
            Debug.LogError("GridHandler reference is not set in GridOccupancyChecker!");
            return;
        }

        // Initialize the occupancy status array based on the number of grid cells
        isOccupied = new bool[gridManager.pinkCells.Length];
    }

    // Function to check if a grid position is occupied
    public bool IsGridPositionOccupied(int cellIndex)
    {
        // Check if the specified cell index is within the bounds of the array
        if (cellIndex >= 0 && cellIndex < gridManager.pinkCells.Length)
        {
            return isOccupied[cellIndex];
        }
        else
        {
            // If the specified position is out of bounds, consider it as occupied
            return true;
        }
    }

    // Function to mark a grid position as occupied
    public void MarkGridPositionOccupied(int cellIndex)
    {
        // Check if the specified cell index is within the bounds of the array
        if (cellIndex >= 0 && cellIndex < gridManager.pinkCells.Length)
        {
            isOccupied[cellIndex] = true;
        }
    }

    // Function to mark a grid position as unoccupied
    public void MarkGridPositionUnoccupied(int cellIndex)
    {
        // Check if the specified cell index is within the bounds of the array
        if (cellIndex >= 0 && cellIndex < gridManager.pinkCells.Length)
        {
            isOccupied[cellIndex] = false;
        }
    }

    // Function to convert world position to grid position
    public int WorldToGridPosition(Vector3 worldPosition)
    {
        // Iterate through each grid cell object to find the one containing the world position
        for (int i = 0; i < gridManager.pinkCells.Length; i++)
        {
            if (gridManager.pinkCells[i].GetComponent<Collider2D>().bounds.Contains(worldPosition))
            {
                return i;
            }
        }

        // If no cell contains the world position, return -1
        return -1;
    }

    // Function to handle collision with pieces
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Piece"))
        {
            // Convert the position of the collider to a grid position
            int gridPos = WorldToGridPosition(other.transform.position);

            // Mark the corresponding grid position as occupied
            MarkGridPositionOccupied(gridPos);

            Debug.Log("agtfytfy");

        }
    }

    // Function to handle exit from collision with pieces
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Piece"))
        {
            // Convert the position of the collider to a grid position
            int gridPos = WorldToGridPosition(other.transform.position);

            // Mark the corresponding grid position as unoccupied
            MarkGridPositionUnoccupied(gridPos);

            Debug.Log("asdsa");
        }
    }
}


