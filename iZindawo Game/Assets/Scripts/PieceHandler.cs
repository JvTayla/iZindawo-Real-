using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*public class PieceMovementHandler : MonoBehaviour
{
    public GameObject[] pieces;
    public float moveSpeed = 5f;
    private int selectedPieceIndex = -1;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null)
            {
                if (hit.transform.CompareTag("Piece"))
                {
                    if (selectedPieceIndex != -1)
                    {
                        // Deselect the previously selected piece
                        pieces[selectedPieceIndex].GetComponent<PieceMovementTest>().SetSelected(false);
                    }

                    // Select the new piece
                    selectedPieceIndex = Array.IndexOf(pieces, hit.transform.gameObject);
                    pieces[selectedPieceIndex].GetComponent<PieceMovementTest>().SetSelected(true);
                }
            }
        }
        else if (Input.GetMouseButtonDown(1))
        {
            // Right-click to deselect
            if (selectedPieceIndex != -1)
            {
                pieces[selectedPieceIndex].GetComponent<PieceMovementTest>().SetSelected(false);
                selectedPieceIndex = -1;
            }
        }

        MoveSelectedPiece();
    }

    void MoveSelectedPiece()
    {
        if (selectedPieceIndex != -1)
        {
            for (int i = 0; i < pieces.Length; i++)
            {
                if (i != selectedPieceIndex)
                {
                    pieces[i].GetComponent<PieceMovementTest>().SetSelected(false);
                }
            }
        }
    }
}*/

/* Yippeeee it helps move the pieces one by one , and pieces snap to the collider centre 
 * 
public class PieceMovementHandler : MonoBehaviour
{
    public GameObject[] pieces;
    private int selectedPieceIndex = -1;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null)
            {
                if (hit.transform.CompareTag("Piece"))
                {
                    int newSelectedIndex = Array.IndexOf(pieces, hit.transform.gameObject);

                    if (newSelectedIndex != selectedPieceIndex)
                    {
                        DeselectAllPieces();
                        selectedPieceIndex = newSelectedIndex;
                        pieces[selectedPieceIndex].GetComponent<PieceMovementTest>().SetSelected(true);
                    }
                }
            }
        }
        else if (Input.GetMouseButtonDown(1))
        {
            DeselectAllPieces();
        }
    }

    void DeselectAllPieces()
    {
        foreach (GameObject piece in pieces)
        {
            piece.GetComponent<PieceMovementTest>().SetSelected(false);
        }
        selectedPieceIndex = -1;
    }
}*/



/*public class PieceMovementHandler : MonoBehaviour
{
    public GameObject[] pieces;
    private int selectedPieceIndex = -1;
    private Vector3 previousPosition;
    private GridOccupancyHandler gridOccupancyHandler;

    void Start()
    {
        gridOccupancyHandler = FindObjectOfType<GridOccupancyHandler>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null)
            {
                if (hit.transform.CompareTag("Piece"))
                {
                    int newSelectedIndex = System.Array.IndexOf(pieces, hit.transform.gameObject);

                    if (newSelectedIndex != selectedPieceIndex)
                    {
                        DeselectAllPieces();
                        selectedPieceIndex = newSelectedIndex;
                        pieces[selectedPieceIndex].GetComponent<PieceMovementTest>().SetSelected(true);
                        previousPosition = pieces[selectedPieceIndex].transform.position;
                    }
                }
            }
        }
        else if (Input.GetMouseButtonDown(1))
        {
            DeselectAllPieces();
        }

        MoveSelectedPiece();
    }

    void DeselectAllPieces()
    {
        foreach (GameObject piece in pieces)
        {
            piece.GetComponent<PieceMovementTest>().SetSelected(false);
        }
        selectedPieceIndex = -1;
    }

    void MoveSelectedPiece()
    {
        if (selectedPieceIndex != -1)
        {
            bool canMove = pieces[selectedPieceIndex].GetComponent<PieceMovementTest>().CanMove();

            if (canMove)
            {
                for (int i = 0; i < pieces.Length; i++)
                {
                    if (i != selectedPieceIndex)
                    {
                        pieces[i].GetComponent<PieceMovementTest>().SetSelected(false);
                    }
                }

                int selectedPieceGridIndex = System.Array.IndexOf(gridOccupancyHandler.pieces, pieces[selectedPieceIndex]);
                gridOccupancyHandler.SetGridCellOccupied(selectedPieceGridIndex, true);
            }
            else
            {
                // Move the piece back to its previous position
                pieces[selectedPieceIndex].transform.position = previousPosition;
                int selectedPieceGridIndex = System.Array.IndexOf(gridOccupancyHandler.pieces, pieces[selectedPieceIndex]);
                gridOccupancyHandler.SetGridCellOccupied(selectedPieceGridIndex, false);
            }
        }
    }
}*/

public class PieceMovementHandler : MonoBehaviour
{
    public GameObject[] pieces;
    private int selectedPieceIndex = -1;
    private Vector3 previousPosition;
    private GridOccupancyHandler gridOccupancyHandler;

    void Start()
    {
        gridOccupancyHandler = FindObjectOfType<GridOccupancyHandler>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null)
            {
                if (hit.transform.CompareTag("Piece"))
                {
                    int newSelectedIndex = System.Array.IndexOf(pieces, hit.transform.gameObject);

                    if (newSelectedIndex != selectedPieceIndex)
                    {
                        DeselectAllPieces();
                        selectedPieceIndex = newSelectedIndex;
                        pieces[selectedPieceIndex].GetComponent<PieceMovementTest>().SetSelected(true);
                        previousPosition = pieces[selectedPieceIndex].transform.position;
                    }
                }
            }
        }
        else if (Input.GetMouseButtonDown(1))
        {
            DeselectAllPieces();
        }

        MoveSelectedPiece();
    }

    void DeselectAllPieces()
    {
        foreach (GameObject piece in pieces)
        {
            piece.GetComponent<PieceMovementTest>().SetSelected(false);
            int pieceGridIndex = System.Array.IndexOf(gridOccupancyHandler.pieces, piece);
            gridOccupancyHandler.SetGridCellOccupied(pieceGridIndex, true);
        }
        selectedPieceIndex = -1;
    }

    void MoveSelectedPiece()
    {
        if (selectedPieceIndex != -1)
        {
            bool canMove = pieces[selectedPieceIndex].GetComponent<PieceMovementTest>().CanMove();

            if (canMove)
            {
                for (int i = 0; i < pieces.Length; i++)
                {
                    if (i != selectedPieceIndex)
                    {
                        pieces[i].GetComponent<PieceMovementTest>().SetSelected(false);
                        int pieceGridIndex = System.Array.IndexOf(gridOccupancyHandler.pieces, pieces[i]);
                        gridOccupancyHandler.SetGridCellOccupied(pieceGridIndex, true);
                    }
                }

                int selectedPieceGridIndex = System.Array.IndexOf(gridOccupancyHandler.pieces, pieces[selectedPieceIndex]);
                gridOccupancyHandler.SetGridCellOccupied(selectedPieceGridIndex, true);
            }
            else
            {
                // Move the piece back to its previous position
                pieces[selectedPieceIndex].transform.position = previousPosition;
                int selectedPieceGridIndex = System.Array.IndexOf(gridOccupancyHandler.pieces, pieces[selectedPieceIndex]);
                gridOccupancyHandler.SetGridCellOccupied(selectedPieceGridIndex, true);
            }
        }
    }
}

