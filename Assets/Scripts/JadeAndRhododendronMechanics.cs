using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class JadeAndRhododendronMechanics : Piece
{
    public JadeAndRhododendronMechanics()
    {
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

    public override bool CanMove(Vector3 desiredPosition)
    {
        return CanMove(currentPosition, desiredPosition);
    }

    public override bool CanMove(Vector3 source, Vector3 target)
    {
        for (int i = 1; i <= 3; i++)
        {
            Vector2 v = new Vector2(source.x + 1, source.y);
            if (boardManager.IsValidBoardPoint(v) && target.x == v.x && target.y == v.y)
            {
                return true;
            }
            if (boardManager.GetOccupation((int)v.x, (int)v.y) || boardManager.GetMembership((int)v.x, (int)v.y).IsWall())
            {
                break;
            }
        }

        for (int i = 1; i <= 3; i++)
        {
            Vector2 v = new Vector2(source.x - 1, source.y);
            if (boardManager.IsValidBoardPoint(v) && target.x == v.x && target.y == v.y)
            {
                return true;
            }
            if (boardManager.GetOccupation((int)v.x, (int)v.y) || boardManager.GetMembership((int)v.x, (int)v.y).IsWall())
            {
                break;
            }
        }

        for (int i = 1; i <= 3; i++)
        {
            Vector2 v = new Vector2(source.x, source.y + 1);
            if (boardManager.IsValidBoardPoint(v) && target.x == v.x && target.y == v.y)
            {
                return true;
            }
            if (boardManager.GetOccupation((int)v.x, (int)v.y) || boardManager.GetMembership((int)v.x, (int)v.y).IsWall())
            {
                break;
            }
        }

        for (int i = 1; i <= 3; i++)
        {
            Vector2 v = new Vector2(source.x, source.y - 1);
            if (boardManager.IsValidBoardPoint(v) && target.x == v.x && target.y == v.y)
            {
                return true;
            }
            if (boardManager.GetOccupation((int)v.x, (int)v.y) || boardManager.GetMembership((int)v.x, (int)v.y).IsWall())
            {
                break;
            }
        }
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

    public override List<Vector2> GetPossibleMoves()
    {
        List<Vector2> list = new List<Vector2>();
        Vector2 source = currentPosition;
        for (int i = 1; i <= 3; i++)
        {
            Vector2 v = new Vector2(source.x + 1, source.y);
            if (boardManager.IsValidBoardPoint(v))
            {
                list.Add(v);
            }
            if (boardManager.GetOccupation((int)v.x, (int)v.y) || boardManager.GetMembership((int)v.x, (int)v.y).IsWall())
            {
                break;
            }
        }
        
        for (int i = 1; i <= 3; i++)
        {
            Vector2 v = new Vector2(source.x - 1, source.y);
            if (boardManager.IsValidBoardPoint(v))
            {
                list.Add(v);
            }
            if (boardManager.GetOccupation((int)v.x, (int)v.y) || boardManager.GetMembership((int)v.x, (int)v.y).IsWall())
            {
                break;
            }
        }
        
        for (int i = 1; i <= 3; i++)
        {
            Vector2 v = new Vector2(source.x, source.y + 1);
            if (boardManager.IsValidBoardPoint(v))
            {
                list.Add(v);
            }
            if (boardManager.GetOccupation((int)v.x, (int)v.y) || boardManager.GetMembership((int)v.x, (int)v.y).IsWall())
            {
                break;
            }
        }
        
        for (int i = 1; i <= 3; i++)
        {
            Vector2 v = new Vector2(source.x, source.y - 1);
            if (boardManager.IsValidBoardPoint(v))
            {
                list.Add(v);
            }
            if (boardManager.GetOccupation((int)v.x, (int)v.y) || boardManager.GetMembership((int)v.x, (int)v.y).IsWall())
            {
                break;
            }
        }
        
        return list;
    }

    public override List<Vector2> GetHarmoniousIntersections()
    {
        List<Vector2> list = new List<Vector2>();
        Vector2 source = currentPosition;
        for (int i = 1; i <= 3; i++)
        {
            Vector2 v = new Vector2(source.x + 1, source.y);
            GameObject o = boardManager.GetOccupation((int)v.x, (int)v.y);
            if (boardManager.IsValidBoardPoint(v) && o != null)
            {
                list.Add(v);
            }
            if (o != null || boardManager.GetMembership((int)v.x, (int)v.y).IsWall())
            {
                break;
            }
        }
        
        for (int i = 1; i <= 3; i++)
        {
            Vector2 v = new Vector2(source.x - 1, source.y);
            GameObject o = boardManager.GetOccupation((int)v.x, (int)v.y);
            if (boardManager.IsValidBoardPoint(v) && o != null)
            {
                list.Add(v);
            }
            if (o != null || boardManager.GetMembership((int)v.x, (int)v.y).IsWall())
            {
                break;
            }
        }
        
        for (int i = 1; i <= 3; i++)
        {
            Vector2 v = new Vector2(source.x, source.y + 1);
            GameObject o = boardManager.GetOccupation((int)v.x, (int)v.y);
            if (boardManager.IsValidBoardPoint(v) && o != null)
            {
                list.Add(v);
            }
            if (o != null || boardManager.GetMembership((int)v.x, (int)v.y).IsWall())
            {
                break;
            }
        }
        
        for (int i = 1; i <= 3; i++)
        {
            Vector2 v = new Vector2(source.x, source.y - 1);
            GameObject o = boardManager.GetOccupation((int)v.x, (int)v.y);
            if (boardManager.IsValidBoardPoint(v) && o != null)
            {
                list.Add(v);
            }
            if (o != null || boardManager.GetMembership((int)v.x, (int)v.y).IsWall())
            {
                break;
            }
        }
        
        return list;
    }
}

