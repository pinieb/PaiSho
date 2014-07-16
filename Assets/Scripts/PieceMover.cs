using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PieceMover : MonoBehaviour
{
	public BoardManager boardManager;
	public GameManager gameManager;
    public SovereigntyManager sovereigntyManager;
	private Vector3 screenPoint;
	private Vector3 initialPosition;
	private Piece p;

	void OnMouseDown()
	{
		p = (Piece)gameObject.GetComponent(typeof(Piece));
		if (gameManager.IsMoveable(p))
		{
			initialPosition = gameObject.transform.position;
			screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
		}
		//Debug.Log("clicked!");
	}

	void OnMouseDrag()
	{
		if (gameManager.IsMoveable(p))
		{
			Vector3 currentScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
			Vector3 currentPos = Camera.main.ScreenToWorldPoint(currentScreenPoint);
			currentPos.z = -2;
			transform.position = currentPos;
		}
	}

	void OnMouseUp()
	{
		if (gameManager.IsMoveable(p))
		{
			Vector3 currentScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
			Vector3 currentPos = Camera.main.ScreenToWorldPoint(currentScreenPoint);
			currentPos.x = Mathf.Round(currentPos.x * 2f) / 2f;
			currentPos.y = Mathf.Round(currentPos.y * 2f) / 2f;
			currentPos.z = -1;
			//currentPos = GetClosestIntersectionToPosition(currentPos).transform.position;

			//Debug.Log (currentPos.ToString());

			if (isValidMove(currentPos))
			{
				// handle updates to harmony and board
				Vector2 source = WorldToBoardConverter.WorldToBoard(initialPosition);
				Vector2 destination = WorldToBoardConverter.WorldToBoard(currentPos);
				boardManager.MovePiece((int)source.x, (int)source.y, (int)destination.x, (int)destination.y);
				((Piece)gameObject.GetComponent(typeof(Piece))).currentPosition = destination;
				transform.position = currentPos;
				gameManager.EndTurn();
			}
			else
			{
				transform.position = initialPosition;
			}
		}
	}

	private bool isValidMove(Vector3 position)
	{
		// Check if the move is in the board area
		if (Vector3.Distance(position, new Vector3(0f, 0f, 0f)) > 4.6f)
		{
			return false;
		}

		// check if the piece can move like that
		Piece type = (Piece)gameObject.GetComponent(typeof(Piece));
		Vector2 board = WorldToBoardConverter.WorldToBoard(position);
		if (type.CanMove(board))
		{
            GameObject o = boardManager.GetOccupation((int)board.x, (int)board.y);
			if (o != null)
            {
                Piece objPiece = (Piece)o.GetComponent(typeof(Piece));
                if (objPiece.Owner != p.Owner &&
                    p.CanCapture(board))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            // rules governing newly dropped pieces
            if (gameManager.DroppedPiece == p)
            {
                if (boardManager.GetOccupation((int)board.x, (int)board.y) != null)
                {
                        return false;
                }
                bool single;
                Piece ruler = sovereigntyManager.WhoHasSovereignty((int)board.x, (int)board.y, out single);

                // can't move into garden controlled by single sovereignty
                // or to threaten a partial sovereign in its own garden
                if (ruler != null && ruler.Owner != p.Owner)
                {
                    if (single)
                    {
                        return false;
                    }
                    else if (p.CanCapture(board, ruler.currentPosition))
                    {
                        return false;
                    }
                }

                // make sure no single sovereign is threatened
                List<Sovereign> sovereigns = sovereigntyManager.GetSovereigns();
                foreach (Sovereign s in sovereigns)
                {
                    if (s.single && s.piece.Owner != type.Owner && p.CanCapture(board, s.piece.currentPosition))
                    {
                        return false;
                    }
                }
            }

			return true;
		}

		return false;
	}

	private GameObject GetClosestIntersectionToPosition(Vector3 position)
	{
		GameObject closest = null;
		float distance = float.MaxValue;

		foreach (GameObject o in GameObject.FindGameObjectsWithTag("Intersection"))
		{
			if (Vector3.Distance(position, o.transform.position) < distance)
			{
				closest = o;
			}
		}

		return closest;
	}
}
