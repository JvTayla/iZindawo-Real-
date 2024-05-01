using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntersectionManager : MonoBehaviour
{
    // Board grid size
    private int gridSizeX = 5;
    private int gridSizeY = 5;

    // Grid cell size
    private float cellSize = 1f;

    // Method to check for adjacent pieces of the same color near the intersection
    public void CheckForAdjacentPieces(GameObject intersection, GameObject[] pieces)
    {
        List<GameObject> adjacentPieces = new List<GameObject>();

        Vector2 intersectionGridPosition = GetGridPosition(intersection.transform.position);

        foreach (GameObject piece in pieces)
        {
            Vector2 pieceGridPosition = GetGridPosition(piece.transform.position);

            if (IsAdjacentToIntersection(intersectionGridPosition, pieceGridPosition))
            {
                adjacentPieces.Add(piece);
            }
        }

        if (adjacentPieces.Count == 3 && AreSameColor(adjacentPieces))
        {
            MovePiecesIntoIntersection(intersection, adjacentPieces);
        }
    }

    // Method to check if a piece is adjacent to the intersection
    private bool IsAdjacentToIntersection(Vector2 intersectionPosition, Vector2 piecePosition)
    {
        float distance = Vector2.Distance(intersectionPosition, piecePosition);
        return distance <= 1.5f; // Adjust this value as needed based on your game's grid size
    }

    // Method to convert world position to grid position
    private Vector2 GetGridPosition(Vector3 worldPosition)
    {
        int x = Mathf.FloorToInt((worldPosition.x + gridSizeX * cellSize / 2) / cellSize);
        int y = Mathf.FloorToInt((worldPosition.z + gridSizeY * cellSize / 2) / cellSize);

        return new Vector2(x, y);
    }

    // Method to check if all pieces in the list are of the same color
    private bool AreSameColor(List<GameObject> pieces)
    {
        Color pieceColor = pieces[0].GetComponent<Renderer>().material.color;

        foreach (GameObject piece in pieces)
        {
            if (piece.GetComponent<Renderer>().material.color != pieceColor)
            {
                return false;
            }
        }

        return true;
    }

    // Method to move pieces into the intersection
    private void MovePiecesIntoIntersection(GameObject intersection, List<GameObject> pieces)
    {
        foreach (GameObject piece in pieces)
        {
            piece.transform.position = intersection.transform.position;
        }
    }
}
