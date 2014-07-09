using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{
	public Player Player1;
	public Player Player2;

	public Player TurnToMove
	{
		get;
		private set;
	}

	public int TurnNumber
	{
		get;
		private set;
	}

	public Piece DroppedPiece
	{
		get;
		private set;
	}

	// Use this for initialization
	void Start () 
	{
		TurnToMove = Player1;
		TurnNumber = 1;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void EndTurn()
	{
		if (TurnToMove == Player1)
		{
			TurnToMove = Player2;
		}
		else
		{
			TurnToMove = Player1;
		}
		TurnNumber++;
		DroppedPiece = null;
	}

	public bool IsMoveable(Piece p)
	{
		if (p != null && (DroppedPiece == null || DroppedPiece == p) && p.Owner == TurnToMove)
		{
			return true;
		}
		return false;
	}

	public void PieceDropped(Piece p)
	{
		DroppedPiece = p;
	}
}
