using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LilyAndChrysanthemumMechanics : Piece
{
    public LilyAndChrysanthemumMechanics()
    {
    }

    public override bool CanMove(Vector3 desiredPosition)
    {
        return CanMove(currentPosition, desiredPosition);
    }
    
    public override TileTypes GetTileType ()
    {
        return Type;
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
    
    public override bool CanCapture(Vector3 source, Vector3 target)
    {
        if ((Mathf.Sign(target.x - source.x) < 0 && Mathf.Sign(target.y - source.y) < 0) ||
            (Mathf.Sign(target.x - source.y) < 0 && Mathf.Sign(target.y - source.y) > 0) ||
            (Mathf.Sign(target.x - source.y) > 0 && Mathf.Sign(target.y - source.y) > 0) ||
            (Mathf.Sign(target.x - source.y) < 0 && Mathf.Sign(target.y - source.y) > 0))
        {
            for (int i = 1; i <= 3; i++)
            {
                int signX = (int)Mathf.Sign(target.x - source.x);
                int signY = (int)Mathf.Sign(target.y - source.y);
                Vector2 temp = new Vector2(source.x + signX * i, source.y + signY * i);
                if (boardManager.IsValidBoardPoint(temp)) 
                {
                    if (temp.x == target.x && temp.y == target.y)
                    {
                        return true;
                    }
                    else if (boardManager.GetOccupation((int)temp.x, (int)temp.y) != null)
                    {
                        return false;
                    }
                }
            }
        }
        
        return false;
    }
    
    public override bool CanCapture(Vector3 target)
    {
        return CanCapture(currentPosition, target);
    }
    
    public override List<Vector2> GetHarmoniousIntersections()
    {
        List<Vector2> list = new List<Vector2>();

        for (int i = 1; i <= 3; i++)
        {
            Vector2 v = new Vector2(currentPosition.x + i, currentPosition.y + i);
            if (boardManager.IsValidBoardPoint(v) && boardManager.GetOccupation((int)v.x, (int)v.y) != null)
            {
                list.Add(v);
                break;
            }
        }

        for (int i = 1; i <= 3; i++)
        {
            Vector2 v = new Vector2(currentPosition.x + i, currentPosition.y - i);
            if (boardManager.IsValidBoardPoint(v) && boardManager.GetOccupation((int)v.x, (int)v.y) != null)
            {
                list.Add(v);
                break;
            }
        }

        for (int i = 1; i <= 3; i++)
        {
            Vector2 v = new Vector2(currentPosition.x - i, currentPosition.y - i);
            if (boardManager.IsValidBoardPoint(v) && boardManager.GetOccupation((int)v.x, (int)v.y) != null)
            {
                list.Add(v);
                break;
            }
        }

        for (int i = 1; i <= 3; i++)
        {
            Vector2 v = new Vector2(currentPosition.x - i, currentPosition.y + i);
            if (boardManager.IsValidBoardPoint(v) && boardManager.GetOccupation((int)v.x, (int)v.y) != null)
            {
                list.Add(v);
                break;
            }
        }
        
        return list;
    }

    public override bool CanMove(Vector3 source, Vector3 target)
    {
        // one ixn horiz. or vert.
        Vector2 temp = new Vector2(source.x - 1, source.y);
        if (target.x == temp.x && target.y == temp.y && 
            boardManager.IsValidBoardPoint(temp) && boardManager.GetOccupation((int)temp.x, (int)temp.y) == null)
        {
            return true;
        }
        temp.x = source.x + 1;
        if (target.x == temp.x && target.y == temp.y && 
            boardManager.IsValidBoardPoint(temp) && boardManager.GetOccupation((int)temp.x, (int)temp.y) == null)
        {
            return true;
        }
        temp.x = source.x;
        temp.y = source.y - 1;
        if (target.x == temp.x && target.y == temp.y && 
            boardManager.IsValidBoardPoint(temp) && boardManager.GetOccupation((int)temp.x, (int)temp.y) == null)
        {
            return true;
        }
        temp.y = source.y + 1;
        if (target.x == temp.x && target.y == temp.y && 
            boardManager.IsValidBoardPoint(temp) && boardManager.GetOccupation((int)temp.x, (int)temp.y) == null)
        {
            return true;
        }

        // up to 3 diag.
        for (int i = 1; i <= 3; i++)
        {
            Vector2 v = new Vector2(source.x + i, source.y + i);
            if (boardManager.IsValidBoardPoint(v))
            {
                if (target.x == v.x && target.y == v.y)
                {
                    return true;
                }
                else if (boardManager.GetOccupation((int)v.x, (int)v.y) != null)
                {
                    break;
                }
            }
        }

        for (int i = 1; i <= 3; i++)
        {
            Vector2 v = new Vector2(source.x + i, source.y - i);
            if (boardManager.IsValidBoardPoint(v))
            {
                if (target.x == v.x && target.y == v.y)
                {
                    return true;
                }
                else if (boardManager.GetOccupation((int)v.x, (int)v.y) != null)
                {
                    break;
                }
            }
        }

        for (int i = 1; i <= 3; i++)
        {
            Vector2 v = new Vector2(source.x - i, source.y - i);
            if (boardManager.IsValidBoardPoint(v))
            {
                if (target.x == v.x && target.y == v.y)
                {
                    return true;
                }
                else if (boardManager.GetOccupation((int)v.x, (int)v.y) != null)
                {
                    break;
                }
            }
        }

        for (int i = 1; i <= 3; i++)
        {
            Vector2 v = new Vector2(source.x - i, source.y - i);
            if (boardManager.IsValidBoardPoint(v))
            {
                if (target.x == v.x && target.y == v.y)
                {
                    return true;
                }
                else if (boardManager.GetOccupation((int)v.x, (int)v.y) != null)
                {
                    break;
                }
            }
        }

        return false;
    }

    public override List<Vector2> GetPossibleMoves()
    {
        List<Vector2> list = new List<Vector2>();
        // one ixn horiz. or vert.
        Vector2 temp = new Vector2(currentPosition.x - 1, currentPosition.y);
        if (boardManager.IsValidBoardPoint(temp) && boardManager.GetOccupation((int)temp.x, (int)temp.y) == null)
        {
            list.Add(new Vector2(temp.x, temp.y));
        }
        temp.x = currentPosition.x + 1;
        if (boardManager.IsValidBoardPoint(temp) && boardManager.GetOccupation((int)temp.x, (int)temp.y) == null)
        {
            list.Add(new Vector2(temp.x, temp.y));
        }
        temp.x = currentPosition.x;
        temp.y = currentPosition.y - 1;
        if (boardManager.IsValidBoardPoint(temp) && boardManager.GetOccupation((int)temp.x, (int)temp.y) == null)
        {
            list.Add(new Vector2(temp.x, temp.y));
        }
        temp.y = currentPosition.y + 1;
        if (boardManager.IsValidBoardPoint(temp) && boardManager.GetOccupation((int)temp.x, (int)temp.y) == null)
        {
            list.Add(new Vector2(temp.x, temp.y));
        }
        
        // up to 3 diag.
        for (int i = 1; i <= 3; i++)
        {
            Vector2 v = new Vector2(currentPosition.x + i, currentPosition.y + i);
            if (boardManager.IsValidBoardPoint(v))
            {
                if (boardManager.GetOccupation((int)v.x, (int)v.y) == null)
                {
                    list.Add(v);
                }
                else
                {
                    break;
                }
            }
        }
        
        for (int i = 1; i <= 3; i++)
        {
            Vector2 v = new Vector2(currentPosition.x + i, currentPosition.y - i);
            if (boardManager.IsValidBoardPoint(v))
            {
                if (boardManager.GetOccupation((int)v.x, (int)v.y) == null)
                {
                    list.Add(v);
                }
                else
                {
                    break;
                }
            }
        }
        
        for (int i = 1; i <= 3; i++)
        {
            Vector2 v = new Vector2(currentPosition.x - i, currentPosition.y - i);
            if (boardManager.IsValidBoardPoint(v))
            {
                if (boardManager.GetOccupation((int)v.x, (int)v.y) == null)
                {
                    list.Add(v);
                }
                else
                {
                    break;
                }
            }
        }
        
        for (int i = 1; i <= 3; i++)
        {
            Vector2 v = new Vector2(currentPosition.x - i, currentPosition.y + i);
            if (boardManager.IsValidBoardPoint(v))
            {
                if (boardManager.GetOccupation((int)v.x, (int)v.y) == null)
                {
                    list.Add(v);
                }
                else
                {
                    break;
                }
            }
        }
        
        return list;
    }
}


