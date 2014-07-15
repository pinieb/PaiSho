using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Rose : Piece
{
    public Rose ()
    {
        Harmony = 0;
        Color = TileColor.Red;
        currentPosition = new Vector3(0, 0, -1);
        Type = TileTypes.Rose;
    }
    
    public override bool CanMove(Vector3 desiredPosition)
    {
        return CanMove(currentPosition, desiredPosition);
    }
    
    public override bool CanMove (Vector3 source, Vector3 target)
    {
        // Can move one intersection vertically or horizontally, and then one diagonally
        // Cannot collide with pieces on its path
        // Cannot jump diagonally over walls
        
        if (target.x < 0f || target.x > 18f || target.y < 0f|| target.y > 18f)
        {
            return false;
        }
        
        Membership currentMembership = boardManager.GetMembership((int)source.x, (int)source.y);
        Membership targetMembership = boardManager.GetMembership((int)target.x, (int)target.y);
        // check that it's a valid intersection
        if (targetMembership == null)
        {
            return false;
        }
        
        // check wall pause
        if ((Mathf.Abs (source.x - target.x) == 0 && Mathf.Abs(source.y - target.y) == 1) ||
            (Mathf.Abs (source.x - target.x) == 1 && Mathf.Abs(source.y - target.y) == 0))
        {
            Membership desMem = boardManager.GetMembership((int)target.x, (int)target.y);
            if (currentMembership.OnlyYellow && desMem.IsWall() && !desMem.Torii)
            {
                return true;
            }
        }
        
        Membership stepMembership;
        float x, y;
        if (Mathf.Abs(source.x - target.x) == 2 && Mathf.Abs(source.y - target.y) == 1)
        {
            // check paths for tiles and walls
            // get path
            // get first ixn
            x = source.x + Mathf.Sign(target.x - source.x);
            y = source.y;
        }
        else if (Mathf.Abs(source.x - target.x) == 1 && Mathf.Abs(source.y - target.y) == 2)
        {
            // check paths for tiles and walls
            // get path
            // get first ixn
            x = source.x;
            y = source.y + Mathf.Sign(target.y - source.y);
        }
        else
        {
            return false;
        }
        
        stepMembership = boardManager.GetMembership((int)x, (int)y);
        if (stepMembership == null || (currentMembership.OnlyYellow && stepMembership.IsWall() && !stepMembership.Torii))
        {
            return false;
        }
        
        if (Membership.InSameGarden(stepMembership, targetMembership))
        {
            return true;
        }
        
        return false;
    }
    
    public override bool CanDrop (Vector3 boardPoint)
    {
        Membership m = boardManager.GetMembership((int)boardPoint.x, (int)boardPoint.y);
        
        if (m != null && m.Neutral && !(m.IsWall() && !m.Torii))
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
    
    public override bool SendsDisharmonyTo (TileTypes receiver)
    {
        if (receiver == TileTypes.Chrysanthemum || receiver == TileTypes.Rhododendron || receiver == TileTypes.Rose)
        {
            return true;
        }
        
        return false;
    }
    
    public override bool SendsHarmonyTo (TileTypes receiver)
    {
        if (receiver == TileTypes.Jasmine || receiver == TileTypes.Jade || receiver == TileTypes.Lily)
        {
            return true;
        }
        
        return false;
    }
}


