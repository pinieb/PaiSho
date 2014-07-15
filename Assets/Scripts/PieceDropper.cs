using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PieceDropper : MonoBehaviour 
{
	public GameObject TileType;
	public BoardManager boardManager;
	public int Available;
	public Player Owner;
	public GameManager gameManager;
    public SovereigntyManager sovereigntyManager;

	private Vector3 screenPoint;
	GameObject tile;
	Piece p;

	void OnMouseDown()
	{
		if (Available > 0 && Owner == gameManager.TurnToMove)
		{
			screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
			//Debug.Log("clicked!");
			tile = (GameObject)Instantiate(TileType, screenPoint, Quaternion.identity);
			((PieceMover)tile.GetComponent(typeof(PieceMover))).boardManager = boardManager;
            ((PieceMover)tile.GetComponent(typeof(PieceMover))).sovereigntyManager = sovereigntyManager;
			p = ((Piece)tile.GetComponent(typeof(Piece)));
			p.boardManager = boardManager;
			p.Owner = Owner;
		}
	}

	void OnMouseDrag()
	{
		if (gameManager.IsMoveable(p))
		{
			Vector3 currentScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
			Vector3 currentPos = Camera.main.ScreenToWorldPoint(currentScreenPoint);
			currentPos.z = -2;
			tile.transform.position = currentPos;
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

			if (IsValidDrop(currentPos))
			{
				tile.transform.position = currentPos;
				tile.transform.parent = transform.parent;
				Available--;
				((PieceMover)tile.GetComponent(typeof(PieceMover))).gameManager = gameManager;
				Vector2 boardPos = WorldToBoardConverter.WorldToBoard(currentPos);
				p.currentPosition = boardPos;
				boardManager.DropPiece((int) boardPos.x, (int)boardPos.y, tile);
				gameManager.PieceDropped(p);
				tile = null;
				p = null;
			}
			else
			{
				DestroyImmediate(tile);
				tile = null;
				p = null;
			}
			//Debug.Log (currentPos.ToString());
			
	//		if (isValidMove(currentPos))
	//		{
	//			// handle updates to harmony and board
	//			Vector2 source = WorldToBoardConverter.WorldToBoard(initialPosition);
	//			Vector2 destination = WorldToBoardConverter.WorldToBoard(currentPos);
	//			boardManager.MovePiece((int)source.x, (int)source.y, (int)destination.x, (int)destination.y);
	//			((Piece)gameObject.GetComponent(typeof(Piece))).Move(currentPos);
	//			transform.position = currentPos;
	//		}
	//		else
	//		{
	//			transform.position = initialPosition;
	//		}
		}
	}

	private bool IsValidDrop(Vector3 position)
	{
		// Check if the move is in the board area
		if (Vector3.Distance(position, new Vector3(0f, 0f, 0f)) > 4.8f)
		{
			return false;
		}

        Vector2 board = WorldToBoardConverter.WorldToBoard(position);

		
		// check if the piece can move like that
		Piece type = (Piece)tile.GetComponent(typeof(Piece));
		if (type.CanDrop(board))
		{
            bool single;
            Piece ruler = sovereigntyManager.WhoHasSovereignty((int)board.x, (int)board.y, out single);

            // can't be dropped into a singly controlled garden
            // or into threat range of a partial sovereign in its own garden
            if (ruler != null && ruler.Owner != type.Owner)
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

            // can't threaten a single sovereign on drop
            List<Sovereign> sovereigns = sovereigntyManager.GetSovereigns();
            foreach (Sovereign s in sovereigns)
            {
                if (s.single && s.piece.Owner != type.Owner && p.CanCapture(board, s.piece.currentPosition))
                {
                    return false;
                }
            }

			return true;
		}
	
		return false;
	}
}
