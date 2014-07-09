using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HarmonyManager : MonoBehaviour
{
	public BoardManager boardManager;

	void Update()
	{
		UpdateHarmony();
	}

	public void UpdateHarmony()
	{
		foreach (Piece p in boardManager.GetPieces())
		{
			p.Harmony = 0;
		}

		foreach (Piece p in boardManager.GetPieces())
		{
			// check if it's in an unharmonious garden
			Membership ixn = boardManager.GetMembership((int)p.currentPosition.x, (int)p.currentPosition.y);
			// if it's a white flower in a red garden, and not touching anything else
			if ((p.Color == TileColor.White && ixn.RedGarden == true) && !(ixn.Torii || ixn.WhiteGarden || ixn.YellowGarden))
			{
				p.Harmony--;
			}
			// else if it's a red flower in a white garden and not touching anything else
			else if ((p.Color == TileColor.Red && ixn.WhiteGarden == true) && !(ixn.Torii || ixn.RedGarden || ixn.YellowGarden))
			{
				p.Harmony--;
			}

			// See if it's sending any harmony
			foreach (Vector2 v in p.GetPossibleMoves())
			{
				GameObject o = boardManager.GetOccupation((int)v.x, (int)v.y);
				if (o != null)
				{
					Piece r = (Piece)o.GetComponent(typeof(Piece));
					if (p.SendsHarmonyTo(r.Type))
					{
						r.Harmony++;
					}
					if (r.Owner != p.Owner && p.SendsDisharmonyTo(r.Type))
					{
						r.Harmony--;
					}
				}
			}
		}
	}
}
