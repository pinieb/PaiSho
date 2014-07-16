using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Orchid : Piece
{
    public Orchid()
    {
        Type = TileTypes.Orchid;
        Color = TileColor.None;
    }

    public override bool CanDrop(Vector3 desiredPosition)
    {
        if (boardManager.IsValidBoardPoint(desiredPosition))
        {
            Membership m = boardManager.GetMembership((int)desiredPosition.x, (int)desiredPosition.y);
            if (!(m.IsWall() && !m.Torii))
            {
                return true;
            }
        }
        
        return false;
    }
    
    public override bool CanMove(Vector3 desiredPosition)
    {
        return CanMove(currentPosition, desiredPosition);
    }
    
    public override bool CanMove(Vector3 source, Vector3 target)
    {
        return false;
    }
    
    public override bool CanCapture(Vector3 target)
    {
        return CanCapture(currentPosition, target);
    }
    
    public override bool CanCapture(Vector3 source, Vector3 target)
    {
        return CanMove(source, target);
    }
    
    public override TileTypes GetTileType()
    {
        return Type;
    }
    
    public override bool SendsDisharmonyTo(TileTypes receiver)
    {
        if (receiver != TileTypes.Air && receiver != TileTypes.ChiBlocker && receiver != TileTypes.Earth &&
            receiver != TileTypes.Fire && receiver != TileTypes.SpiritWheel && receiver != TileTypes.Water &&
            receiver != TileTypes.Orchid)
        {
            return true;
        }
        
        return false;
    }
    
    public override bool SendsHarmonyTo(TileTypes receiver)
    {
        return false;
    }
}