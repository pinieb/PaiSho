using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Sovereign
{
    public Piece piece;
    public bool single;

    public override bool Equals(object o)
    {
        Piece p = o as Piece;
        return piece == p;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}

public class SovereigntyManager : MonoBehaviour
{
    public BoardManager boardManager;

    public Piece WhoHasSovereignty(int x, int y, out bool single)
    {
        List<Piece> list = new List<Piece>();

        if (x >= 2 && x <= 9 && y >= 9 && y <= x + 7)
        {
            for (int i = 2; i <= 9; i++)
            {
                for (int j = 9; j <= i + 7; j++)
                {
                    GameObject o = boardManager.GetOccupation(i, j);
                    if (o != null)
                    {
                        list.Add((Piece)o.GetComponent(typeof(Piece)));
                    }
                }
            }
        }
        else if (x >= 9 && x <= 16 && y >= 9 && y <= 25 - x)
        {
            for (int i = 9; i <= 16; i++)
            {
                for (int j = 9; j <= 25 - i; j++)
                {
                    GameObject o = boardManager.GetOccupation(i, j);
                    if (o != null)
                    {
                        list.Add((Piece)o.GetComponent(typeof(Piece)));
                    }
                }
            }
        }
        else if (x >= 2 && x <= 9 && y >= 11 - x && y <= 9)
        {
            for (int i = 2; i <= 9; i++)
            {
                for (int j = 11 - i; j <= 9; j++)
                {
                    GameObject o = boardManager.GetOccupation(i, j);
                    if (o != null)
                    {
                        list.Add((Piece)o.GetComponent(typeof(Piece)));
                    }
                }
            }
        }
        else if (x >= 9 && x <= 16 && y <= 9 && y >= x - 7)
        {
            for (int i = 9; i <= 16; i++)
            {
                for (int j = i - 7; j <= 9; j++)
                {
                    GameObject o = boardManager.GetOccupation(i, j);
                    if (o != null)
                    {
                        list.Add((Piece)o.GetComponent(typeof(Piece)));
                    }
                }
            }
        }

        if (list.Count == 1)
        {
            single = !boardManager.GetMembership((int)list[0].currentPosition.x, (int)list[0].currentPosition.y).IsWall();
            return list[0];
        }

        single = false;
        return null;
    }

    public List<Sovereign> GetSovereigns()
    {
        List<Sovereign> list = new List<Sovereign>();

        List<Piece> temp = new List<Piece>();
        for (int i = 2; i <= 9; i++)
        {
            for (int j = 9; j <= i + 7; j++)
            {
                GameObject o = boardManager.GetOccupation(i, j);
                if (o != null)
                {
                    temp.Add((Piece)o.GetComponent(typeof(Piece)));
                }
            }
        }

        if (temp.Count == 1)
        {
            Sovereign s = new Sovereign();
            s.single = !boardManager.GetMembership((int)temp[0].currentPosition.x, (int)temp[0].currentPosition.y).IsWall();
            s.piece = temp[0];
            list.Add(s);
        }

        temp.Clear();

        for (int i = 9; i <= 16; i++)
        {
            for (int j = 9; j <= 25 - i; j++)
            {
                GameObject o = boardManager.GetOccupation(i, j);
                if (o != null)
                {
                    temp.Add((Piece)o.GetComponent(typeof(Piece)));
                }
            }
        }

        if (temp.Count == 1)
        {
            Sovereign s = new Sovereign();
            s.single = !boardManager.GetMembership((int)temp[0].currentPosition.x, (int)temp[0].currentPosition.y).IsWall();
            s.piece = temp[0];
            list.Add(s);
        }
        
        temp.Clear();

        for (int i = 2; i <= 9; i++)
        {
            for (int j = 11 - i; j <= 9; j++)
            {
                GameObject o = boardManager.GetOccupation(i, j);
                if (o != null)
                {
                    temp.Add((Piece)o.GetComponent(typeof(Piece)));
                }
            }
        }

        if (temp.Count == 1)
        {
            Sovereign s = new Sovereign();
            s.single = !boardManager.GetMembership((int)temp[0].currentPosition.x, (int)temp[0].currentPosition.y).IsWall();
            s.piece = temp[0];
            list.Add(s);
        }
        
        temp.Clear();

        for (int i = 9; i <= 16; i++)
        {
            for (int j = i - 7; j <= 9; j++)
            {
                GameObject o = boardManager.GetOccupation(i, j);
                if (o != null)
                {
                    temp.Add((Piece)o.GetComponent(typeof(Piece)));
                }
            }
        }

        if (temp.Count == 1)
        {
            Sovereign s = new Sovereign();
            s.single = !boardManager.GetMembership((int)temp[0].currentPosition.x, (int)temp[0].currentPosition.y).IsWall();
            s.piece = temp[0];
            list.Add(s);
        }
        
        temp.Clear();

        return list;
    }
}
