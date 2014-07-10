using UnityEngine;
using System.Collections;

public class PieceMover : MonoBehaviour
{
	public BoardManager boardManager;
	public GameManager gameManager;
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
			if (boardManager.GetOccupation((int)board.x, (int)board.y) != null &&
			    gameManager.DroppedPiece != null)
			{
				return false;
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
