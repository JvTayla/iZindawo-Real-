using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour

{
    
    public GameObject[] pinkCells;
   /* public GameObject[] blueCells;
    public GameObject[] yellowCells;
    public GameObject[] intersectionCells;
    public GameObject[] whiteBlockCells;*/

    void Start()
    {
        // Calculate grid layout for pink cells
        CalculateGridLayout(pinkCells);

        // Calculate grid layout for blue cells
      //  CalculateGridLayout(blueCells);

        // Calculate grid layout for yellow cells
      //  CalculateGridLayout(yellowCells);

        // Calculate grid layout for intersection cells
      //  CalculateGridLayout(intersectionCells);

        // Calculate grid layout for white block cells
      //  CalculateGridLayout(whiteBlockCells);
    }

    // Helper method to calculate grid layout
    void CalculateGridLayout(GameObject[] cells)
    {
        if (cells == null || cells.Length == 0)
        {
            Debug.LogWarning("No cells found.");
            return;
        }

        // Calculate the total width and height of the cells
        float totalWidth = 0f;
        float totalHeight = 0f;

        foreach (GameObject cell in cells)
        {
            totalWidth += cell.GetComponent<Renderer>().bounds.size.x;
            totalHeight += cell.GetComponent<Renderer>().bounds.size.y;
        }

        // Calculate the average width and height
        float avgWidth = totalWidth / cells.Length;
        float avgHeight = totalHeight / cells.Length;

        // Calculate the starting position of the grid
        Vector3 startPos = transform.position;

        // Position the cells in an irregular grid layout without moving them
        for (int i = 0; i < cells.Length; i++)
        {
            // Calculate the position of the current cell
            Vector3 cellPos = CalculateCellPosition(cells[i], i, avgWidth, avgHeight, startPos);

            // Update the position of the GameObject in the grid
            // This is where you would use this position for any tracking or logic
            // For demonstration purposes, we're just printing the position here
            Debug.Log("Position of cell " + i + ": " + cellPos);
        }
    }

    // Helper method to calculate the position of a cell in the grid
    Vector3 CalculateCellPosition(GameObject cell, int index, float avgWidth, float avgHeight, Vector3 startPos)
    {
        // Modify this method to calculate the position of each cell in an irregular grid layout
        // For now, we're positioning the cells in a simple regular grid layout
        float xOffset = index * avgWidth;
        float yOffset = 0f;

        Vector3 cellPos = startPos + new Vector3(xOffset, yOffset, 0f);

        return cellPos;
    }
}
