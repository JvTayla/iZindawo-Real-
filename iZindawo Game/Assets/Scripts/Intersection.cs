using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intersection : MonoBehaviour
{
    // Reference to the IntersectionManager script
    private IntersectionManager intersectionManager;

    // List to store pieces currently in the intersection
    private List<GameObject> piecesInIntersection = new List<GameObject>();

    // Method to initialize IntersectionManager reference
    private void Start()
    {
        intersectionManager = GameObject.FindObjectOfType<IntersectionManager>();
    }

    // Method to add a piece to the intersection
    public void AddPieceToIntersection(GameObject piece)
    {
        piecesInIntersection.Add(piece);
    }

    // Method to remove a piece from the intersection
    public void RemovePieceFromIntersection(GameObject piece)
    {
        piecesInIntersection.Remove(piece);
    }

    // Method to check if the intersection is full
    public bool IsIntersectionFull()
    {
        return piecesInIntersection.Count >= 3;
    }

    // Method to get pieces currently in the intersection
    public List<GameObject> GetPiecesInIntersection()
    {
        return piecesInIntersection;
    }

    // Method to check for adjacent pieces and trigger movement bonus
    public void CheckForAdjacentPieces(GameObject[] pieces)
    {
        intersectionManager.CheckForAdjacentPieces(gameObject, pieces);
    }
}