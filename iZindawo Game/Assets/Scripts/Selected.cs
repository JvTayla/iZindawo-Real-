using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Selected : MonoBehaviour
//{
//    public Color HighlightColor;
//    public Color SelectColor;

//    private Color OriginalColor;
//    private Transform highlight;
//    private Transform selected;

//    void Update()
//    {
//        if (highlight != null && highlight != selected)
//        {
//            highlight.GetComponent<SpriteRenderer>().color = OriginalColor;
//            highlight = null;
//        }
//
//        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
//        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
//
//        if (!EventSystem.current.IsPointerOverGameObject() && hit.collider != null)
//        {
//            highlight = hit.transform;
//            if (highlight.CompareTag("Piece") && highlight != selected)
//            {
//                if (highlight.GetComponent<SpriteRenderer>().color != HighlightColor)
//                {
//                    OriginalColor = highlight.GetComponent<SpriteRenderer>().color;
//                    highlight.GetComponent<SpriteRenderer>().color = HighlightColor;
//                }
//            }
//            else
//            {
//                highlight = null;
//            }
//        }
//
//        if (Input.GetKey(KeyCode.Mouse0) && !EventSystem.current.IsPointerOverGameObject())
//       {
//            if (selected != null)
//            {
//                selected.GetComponent<SpriteRenderer>().color = OriginalColor;
//                selected = null;
//            }
//
//            RaycastHit2D hitSelected = Physics2D.Raycast(ray.origin, ray.direction);
//            if (hitSelected.collider != null)
//            {
//                selected = hitSelected.transform;
//                if (selected.CompareTag("Piece"))
//                {
//                    OriginalColor = selected.GetComponent<SpriteRenderer>().color;
//                    selected.GetComponent<SpriteRenderer>().color = SelectColor;
//                }
//                else
//                {
//                    selected = null;
//                }
//            }
//        }
//    }
//}

{
public Color HighlightColor;
public Color SelectColor;

private Color OriginalColor;
private PieceMovementTest pieceMovementTest;

void Start()
{
    pieceMovementTest = GetComponent<PieceMovementTest>();
}

void Update()
{
    if (Input.GetKey(KeyCode.Mouse0) && !EventSystem.current.IsPointerOverGameObject())
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (hit.collider != null)
        {
            if (hit.transform.CompareTag("Piece"))
            {
                if (pieceMovementTest != null)
                {
                    // Set the selected state of the piece
                    pieceMovementTest.SetSelected(true);

                    // Change the color of the piece to indicate selection
                    OriginalColor = GetComponent<SpriteRenderer>().color;
                    GetComponent<SpriteRenderer>().color = SelectColor;
                }
            }
        }
        else
        {
            // No piece was clicked, so deselect any previously selected piece
            if (pieceMovementTest != null)
            {
                pieceMovementTest.SetSelected(false);

                // Restore the original color of the previously selected piece
                GetComponent<SpriteRenderer>().color = OriginalColor;
            }
        }
    }
}
}


