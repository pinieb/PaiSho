using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Jasmine : Piece
{
	public Jasmine ()
	{
		Harmony = 0;
		Color = TileColor.White;
		currentPosition = new Vector3(0, 0, -1);
		Type = TileTypes.Jasmine;
	}

	public override bool CanMove (Vector3 desired)
	{
		// Can move one intersection vertically or horizontally, and then one diagonally
		// Cannot collide with pieces on its path
		// Cannot jump diagonally over walls

		if (desired.x < 0f || desired.x > 18f || desired.y < 0f|| desired.y > 18f)
		{
			return false;
		}

		Membership currentMembership = boardManager.GetMembership((int)currentPosition.x, (int)currentPosition.y);
		Membership targetMembership = boardManager.GetMembership((int)desired.x, (int)desired.y);
		// check that it's a valid intersection
		if (targetMembership == null)
		{
			return false;
		}

		// check wall pause
		if ((Mathf.Abs (currentPosition.x - desired.x) == 0 && Mathf.Abs(currentPosition.y - desired.y) == 1) ||
		    (Mathf.Abs (currentPosition.x - desired.x) == 1 && Mathf.Abs(currentPosition.y - desired.y) == 0))
		{
			if (currentMembership.OnlyYellow && boardManager.GetMembership((int)desired.x, (int)desired.y).IsWall())
			{
				return true;
			}
		}

		Membership stepMembership;
		float x, y;
		if (Mathf.Abs(currentPosition.x - desired.x) == 2 && Mathf.Abs(currentPosition.y - desired.y) == 1)
		{
			// check paths for tiles and walls
			// get path
			// get first ixn
			x = currentPosition.x + Mathf.Sign(desired.x - currentPosition.x);
			y = currentPosition.y;
		}
		else if (Mathf.Abs(currentPosition.x - desired.x) == 1 && Mathf.Abs(currentPosition.y - desired.y) == 2)
		{
			// check paths for tiles and walls
			// get path
			// get first ixn
			x = currentPosition.x;
			y = currentPosition.y + Mathf.Sign(desired.y - currentPosition.y);
		}
		else
		{
			return false;
		}

		stepMembership = boardManager.GetMembership((int)x, (int)y);
		if (stepMembership == null || (currentMembership.OnlyYellow && stepMembership.IsWall()))
		{
			return false;
		}
		
		if (Membership.InSameGarden(stepMembership, targetMembership))
		{
			return true;
		}
		
		return false;
	}

	public override bool CanDrop (Vector3 desiredPosition)
	{
		Vector2 boardPoint = WorldToBoardConverter.WorldToBoard(desiredPosition);
		Membership m = boardManager.GetMembership((int)boardPoint.x, (int)boardPoint.y);

		if (m != null && m.Neutral && !m.IsWall())
		{
			if (boardManager.GetOccupation((int)boardPoint.x, (int)boardPoint.y) == null)
			{
				return true;
			}
		}

		return false;
	}

	public override List<Vector2> GetPossibleMoves ()
	{
		List<Vector2> moves = new List<Vector2>();

		for (int i = -2; i <= 2; i++)
		{
			for (int j = -2; j <= 2; j++)
			{
				if (CanMove(new Vector3(currentPosition.x + i, currentPosition.y + j, 0)))
				{
					moves.Add(new Vector2(currentPosition.x + i, currentPosition.y + j));
				}
			}
		}

		return moves;
	}

	public override TileTypes GetTileType ()
	{
		return Type;
	}

	public override bool SendsHarmonyTo (TileTypes receiver)
	{
		if (receiver == TileTypes.Chrysanthemum || receiver == TileTypes.Rhododendron || receiver == TileTypes.Rose)
		{
			return true;
		}

		return false;
	}

	public override bool SendsDisharmonyTo (TileTypes receiver)
	{
		if (receiver == TileTypes.Jasmine || receiver == TileTypes.Jade || receiver == TileTypes.Lily)
		{
			return true;
		}

		return false;
	}
}


