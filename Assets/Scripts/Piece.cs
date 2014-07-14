using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum TileColor 
{
	Red, White, None
}

public enum TileTypes
{
	Lily, Jade, Jasmine, Chrysanthemum, Rhododendron, Rose, Lotus, Orchid, ChiBlocker, Air, Water, Earth, Fire, SpiritWheel, None
}

public class Piece : MonoBehaviour
{
	public BoardManager boardManager;
	public bool HasAbility
	{
		get;
		protected set;
	}
	public Player Owner;
	public int Harmony;
	public TileColor Color
	{
		get;
		protected set;
	}
	public Vector3 currentPosition;
	public TileTypes Type
	{
		get;
		protected set;
	}

	public virtual bool CanMove (Vector3 desiredPosition)
	{
		return false;
	}

    public virtual bool CanMove(Vector3 source, Vector3 target)
    {
        return false;
    }

	public virtual bool CanDrop (Vector3 desiredPosition)
	{
		return false;
	}

	public virtual List<Vector2> GetPossibleMoves ()
	{
		return null;
	}

	public virtual TileTypes GetTileType ()
	{
		return TileTypes.None;
	}

	public virtual bool SendsHarmonyTo (TileTypes receiver)
	{
		return false;
	}

	public virtual bool SendsDisharmonyTo (TileTypes receiver)
	{
		return false;
	}
}
