using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

public enum Row
{
	A = 0,
	B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S
}

public class BoardManager : MonoBehaviour
{
	private Membership[,] membership;
	private GameObject[,] occupation;
	public List<Piece> Pieces;

	// Use this for initialization
	void Start ()
	{
		membership = new Membership[19, 19];
		occupation = new GameObject[19, 19];
		Pieces = new List<Piece>();
		#region membership population
		// A9, A10, A11
		membership[0, 8] = new Membership(BorderingGardens.NorthTorii);
		membership[0, 9] = new Membership(BorderingGardens.NorthTorii);
		membership[0, 10] = new Membership(BorderingGardens.NorthTorii);
		// B6, B7, B8, B9, B10, B11, B12, B13, B14
		membership[1, 5] = new Membership(BorderingGardens.Yellow);
		membership[1, 6] = new Membership(BorderingGardens.Yellow);
		membership[1, 7] = new Membership(BorderingGardens.Yellow);
		membership[1, 8] = new Membership(BorderingGardens.NorthTorii_Yellow);
		membership[1, 9] = new Membership(BorderingGardens.NorthTorii);
		membership[1, 10] = new Membership(BorderingGardens.NorthTorii_Yellow);
		membership[1, 11] = new Membership(BorderingGardens.Yellow);
		membership[1, 12] = new Membership(BorderingGardens.Yellow);
		membership[1, 13] = new Membership(BorderingGardens.Yellow);
		// C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15
		membership[2, 4] = new Membership(BorderingGardens.Yellow);
		membership[2, 5] = new Membership(BorderingGardens.Yellow);
		membership[2, 6] = new Membership(BorderingGardens.Yellow);
		membership[2, 7] = new Membership(BorderingGardens.Yellow);
		membership[2, 8] = new Membership(BorderingGardens.Yellow);
		membership[2, 9] = new Membership(BorderingGardens.NorthTorii_Yellow_White_Red);
		membership[2, 10] = new Membership(BorderingGardens.Yellow);
		membership[2, 11] = new Membership(BorderingGardens.Yellow);
		membership[2, 12] = new Membership(BorderingGardens.Yellow);
		membership[2, 13] = new Membership(BorderingGardens.Yellow);
		membership[2, 14] = new Membership(BorderingGardens.Yellow);
		// D4, D5, D6, D7, D8, D9, D10, D11, D12, D13, D14, D15, D16
		membership[3, 3] = new Membership(BorderingGardens.Yellow);
		membership[3, 4] = new Membership(BorderingGardens.Yellow);
		membership[3, 5] = new Membership(BorderingGardens.Yellow);
		membership[3, 6] = new Membership(BorderingGardens.Yellow);
		membership[3, 7] = new Membership(BorderingGardens.Yellow);
		membership[3, 8] = new Membership(BorderingGardens.Yellow_Red);
		membership[3, 9] = new Membership(BorderingGardens.White_Red);
		membership[3, 10] = new Membership(BorderingGardens.Yellow_White);
		membership[3, 11] = new Membership(BorderingGardens.Yellow);
		membership[3, 12] = new Membership(BorderingGardens.Yellow);
		membership[3, 13] = new Membership(BorderingGardens.Yellow);
		membership[3, 14] = new Membership(BorderingGardens.Yellow);
		membership[3, 15] = new Membership(BorderingGardens.Yellow);
		// E3, E4, E5, E6, E7, E8, E9, E10, E11, E12, E13, E14, E15, E16, E17
		membership[4, 2] = new Membership(BorderingGardens.Yellow);
		membership[4, 3] = new Membership(BorderingGardens.Yellow);
		membership[4, 4] = new Membership(BorderingGardens.Yellow);
		membership[4, 5] = new Membership(BorderingGardens.Yellow);
		membership[4, 6] = new Membership(BorderingGardens.Yellow);
		membership[4, 7] = new Membership(BorderingGardens.Yellow_Red);
		membership[4, 8] = new Membership(BorderingGardens.Red);
		membership[4, 9] = new Membership(BorderingGardens.White_Red);
		membership[4, 10] = new Membership(BorderingGardens.White);
		membership[4, 11] = new Membership(BorderingGardens.Yellow_White);
		membership[4, 12] = new Membership(BorderingGardens.Yellow);
		membership[4, 13] = new Membership(BorderingGardens.Yellow);
		membership[4, 14] = new Membership(BorderingGardens.Yellow);
		membership[4, 15] = new Membership(BorderingGardens.Yellow);
		membership[4, 16] = new Membership(BorderingGardens.Yellow);
		// F2, F3, F4, F5, F6, F7, F8, F9, F10, F11, F12, F13, F14, F15, F16, F17, F18
		membership[5, 1] = new Membership(BorderingGardens.Yellow);
		membership[5, 2] = new Membership(BorderingGardens.Yellow);
		membership[5, 3] = new Membership(BorderingGardens.Yellow);
		membership[5, 4] = new Membership(BorderingGardens.Yellow);
		membership[5, 5] = new Membership(BorderingGardens.Yellow);
		membership[5, 6] = new Membership(BorderingGardens.Yellow_Red);
		membership[5, 7] = new Membership(BorderingGardens.Red);
		membership[5, 8] = new Membership(BorderingGardens.Red);
		membership[5, 9] = new Membership(BorderingGardens.White_Red);
		membership[5, 10] = new Membership(BorderingGardens.White);
		membership[5, 11] = new Membership(BorderingGardens.White);
		membership[5, 12] = new Membership(BorderingGardens.Yellow_White);
		membership[5, 13] = new Membership(BorderingGardens.Yellow);
		membership[5, 14] = new Membership(BorderingGardens.Yellow);
		membership[5, 15] = new Membership(BorderingGardens.Yellow);
		membership[5, 16] = new Membership(BorderingGardens.Yellow);
		membership[5, 17] = new Membership(BorderingGardens.Yellow);
		// G2, G3, G4, G5, G6, G7, G8, G9, G10, G11, G12, G13, G14, G15, G16, G17, G18
		membership[6, 1] = new Membership(BorderingGardens.Yellow);
		membership[6, 2] = new Membership(BorderingGardens.Yellow);
		membership[6, 3] = new Membership(BorderingGardens.Yellow);
		membership[6, 4] = new Membership(BorderingGardens.Yellow);
		membership[6, 5] = new Membership(BorderingGardens.Yellow_Red);
		membership[6, 6] = new Membership(BorderingGardens.Red);
		membership[6, 7] = new Membership(BorderingGardens.Red);
		membership[6, 8] = new Membership(BorderingGardens.Red);
		membership[6, 9] = new Membership(BorderingGardens.White_Red);
		membership[6, 10] = new Membership(BorderingGardens.White);
		membership[6, 11] = new Membership(BorderingGardens.White);
		membership[6, 12] = new Membership(BorderingGardens.White);
		membership[6, 13] = new Membership(BorderingGardens.Yellow_White);
		membership[6, 14] = new Membership(BorderingGardens.Yellow);
		membership[6, 15] = new Membership(BorderingGardens.Yellow);
		membership[6, 16] = new Membership(BorderingGardens.Yellow);
		membership[6, 17] = new Membership(BorderingGardens.Yellow);
		// H2-18
		membership[7, 1] = new Membership(BorderingGardens.Yellow);
		membership[7, 2] = new Membership(BorderingGardens.Yellow);
		membership[7, 3] = new Membership(BorderingGardens.Yellow);
		membership[7, 4] = new Membership(BorderingGardens.Yellow_Red);
		membership[7, 5] = new Membership(BorderingGardens.Red);
		membership[7, 6] = new Membership(BorderingGardens.Red);
		membership[7, 7] = new Membership(BorderingGardens.Red);
		membership[7, 8] = new Membership(BorderingGardens.Red);
		membership[7, 9] = new Membership(BorderingGardens.White_Red);
		membership[7, 10] = new Membership(BorderingGardens.White);
		membership[7, 11] = new Membership(BorderingGardens.White);
		membership[7, 12] = new Membership(BorderingGardens.White);
		membership[7, 13] = new Membership(BorderingGardens.White);
		membership[7, 14] = new Membership(BorderingGardens.Yellow_White);
		membership[7, 15] = new Membership(BorderingGardens.Yellow);
		membership[7, 16] = new Membership(BorderingGardens.Yellow);
		membership[7, 17] = new Membership(BorderingGardens.Yellow);
		// I1-19
		membership[8, 0] = new Membership(BorderingGardens.WestTorii);
		membership[8, 1] = new Membership(BorderingGardens.WestTorii_Yellow);
		membership[8, 2] = new Membership(BorderingGardens.Yellow);
		membership[8, 3] = new Membership(BorderingGardens.Yellow_Red);
		membership[8, 4] = new Membership(BorderingGardens.Red);
		membership[8, 5] = new Membership(BorderingGardens.Red);
		membership[8, 6] = new Membership(BorderingGardens.Red);
		membership[8, 7] = new Membership(BorderingGardens.Red);
		membership[8, 8] = new Membership(BorderingGardens.Red);
		membership[8, 9] = new Membership(BorderingGardens.White_Red);
		membership[8, 10] = new Membership(BorderingGardens.White);
		membership[8, 11] = new Membership(BorderingGardens.White);
		membership[8, 12] = new Membership(BorderingGardens.White);
		membership[8, 13] = new Membership(BorderingGardens.White);
		membership[8, 14] = new Membership(BorderingGardens.White);
		membership[8, 15] = new Membership(BorderingGardens.Yellow_White);
		membership[8, 16] = new Membership(BorderingGardens.Yellow);
		membership[8, 17] = new Membership(BorderingGardens.WestTorii_Yellow);
		membership[8, 18] = new Membership(BorderingGardens.WestTorii);
		// J1-19
		membership[9, 0] = new Membership(BorderingGardens.WestTorii);
		membership[9, 1] = new Membership(BorderingGardens.WestTorii);
		membership[9, 2] = new Membership(BorderingGardens.WestTorii_Yellow_White_Red);
		membership[9, 3] = new Membership(BorderingGardens.White_Red);
		membership[9, 4] = new Membership(BorderingGardens.White_Red);
		membership[9, 5] = new Membership(BorderingGardens.White_Red);
		membership[9, 6] = new Membership(BorderingGardens.White_Red);
		membership[9, 7] = new Membership(BorderingGardens.White_Red);
		membership[9, 8] = new Membership(BorderingGardens.White_Red);
		membership[9, 9] = new Membership(BorderingGardens.White_Red);
		membership[9, 10] = new Membership(BorderingGardens.White_Red);
		membership[9, 11] = new Membership(BorderingGardens.White_Red);
		membership[9, 12] = new Membership(BorderingGardens.White_Red);
		membership[9, 13] = new Membership(BorderingGardens.White_Red);
		membership[9, 14] = new Membership(BorderingGardens.White_Red);
		membership[9, 15] = new Membership(BorderingGardens.White_Red);
		membership[9, 16] = new Membership(BorderingGardens.WestTorii_Yellow_White_Red);
		membership[9, 17] = new Membership(BorderingGardens.WestTorii);
		membership[9, 18] = new Membership(BorderingGardens.WestTorii);
		// K1-19
		membership[10, 0] = new Membership(BorderingGardens.WestTorii);
		membership[10, 1] = new Membership(BorderingGardens.WestTorii_Yellow);
		membership[10, 2] = new Membership(BorderingGardens.Yellow);
		membership[10, 3] = new Membership(BorderingGardens.Yellow_White);
		membership[10, 4] = new Membership(BorderingGardens.White);
		membership[10, 5] = new Membership(BorderingGardens.White);
		membership[10, 6] = new Membership(BorderingGardens.White);
		membership[10, 7] = new Membership(BorderingGardens.White);
		membership[10, 8] = new Membership(BorderingGardens.White);
		membership[10, 9] = new Membership(BorderingGardens.White_Red);
		membership[10, 10] = new Membership(BorderingGardens.Red);
		membership[10, 11] = new Membership(BorderingGardens.Red);
		membership[10, 12] = new Membership(BorderingGardens.Red);
		membership[10, 13] = new Membership(BorderingGardens.Red);
		membership[10, 14] = new Membership(BorderingGardens.Red);
		membership[10, 15] = new Membership(BorderingGardens.Yellow_Red);
		membership[10, 16] = new Membership(BorderingGardens.Yellow);
		membership[10, 17] = new Membership(BorderingGardens.WestTorii_Yellow);
		membership[10, 18] = new Membership(BorderingGardens.WestTorii);
		// L2-18
		membership[11, 1] = new Membership(BorderingGardens.Yellow);
		membership[11, 2] = new Membership(BorderingGardens.Yellow);
		membership[11, 3] = new Membership(BorderingGardens.Yellow);
		membership[11, 4] = new Membership(BorderingGardens.Yellow_White);
		membership[11, 5] = new Membership(BorderingGardens.White);
		membership[11, 6] = new Membership(BorderingGardens.White);
		membership[11, 7] = new Membership(BorderingGardens.White);
		membership[11, 8] = new Membership(BorderingGardens.White);
		membership[11, 9] = new Membership(BorderingGardens.White_Red);
		membership[11, 10] = new Membership(BorderingGardens.Red);
		membership[11, 11] = new Membership(BorderingGardens.Red);
		membership[11, 12] = new Membership(BorderingGardens.Red);
		membership[11, 13] = new Membership(BorderingGardens.Red);
		membership[11, 14] = new Membership(BorderingGardens.Yellow_Red);
		membership[11, 15] = new Membership(BorderingGardens.Yellow);
		membership[11, 16] = new Membership(BorderingGardens.Yellow);
		membership[11, 17] = new Membership(BorderingGardens.Yellow);
		// M2-18
		membership[12, 1] = new Membership(BorderingGardens.Yellow);
		membership[12, 2] = new Membership(BorderingGardens.Yellow);
		membership[12, 3] = new Membership(BorderingGardens.Yellow);
		membership[12, 4] = new Membership(BorderingGardens.Yellow);
		membership[12, 5] = new Membership(BorderingGardens.Yellow_White);
		membership[12, 6] = new Membership(BorderingGardens.White);
		membership[12, 7] = new Membership(BorderingGardens.White);
		membership[12, 8] = new Membership(BorderingGardens.White);
		membership[12, 9] = new Membership(BorderingGardens.White_Red);
		membership[12, 10] = new Membership(BorderingGardens.Red);
		membership[12, 11] = new Membership(BorderingGardens.Red);
		membership[12, 12] = new Membership(BorderingGardens.Red);
		membership[12, 13] = new Membership(BorderingGardens.Yellow_Red);
		membership[12, 14] = new Membership(BorderingGardens.Yellow);
		membership[12, 15] = new Membership(BorderingGardens.Yellow);
		membership[12, 16] = new Membership(BorderingGardens.Yellow);
		membership[12, 17] = new Membership(BorderingGardens.Yellow);
		// N2-18
		membership[13, 1] = new Membership(BorderingGardens.Yellow);
		membership[13, 2] = new Membership(BorderingGardens.Yellow);
		membership[13, 3] = new Membership(BorderingGardens.Yellow);
		membership[13, 4] = new Membership(BorderingGardens.Yellow);
		membership[13, 5] = new Membership(BorderingGardens.Yellow);
		membership[13, 6] = new Membership(BorderingGardens.Yellow_White);
		membership[13, 7] = new Membership(BorderingGardens.White);
		membership[13, 8] = new Membership(BorderingGardens.White);
		membership[13, 9] = new Membership(BorderingGardens.White_Red);
		membership[13, 10] = new Membership(BorderingGardens.Red);
		membership[13, 11] = new Membership(BorderingGardens.Red);
		membership[13, 12] = new Membership(BorderingGardens.Yellow_Red);
		membership[13, 13] = new Membership(BorderingGardens.Yellow);
		membership[13, 14] = new Membership(BorderingGardens.Yellow);
		membership[13, 15] = new Membership(BorderingGardens.Yellow);
		membership[13, 16] = new Membership(BorderingGardens.Yellow);
		membership[13, 17] = new Membership(BorderingGardens.Yellow);
		// O3-17
		membership[14, 2] = new Membership(BorderingGardens.Yellow);
		membership[14, 3] = new Membership(BorderingGardens.Yellow);
		membership[14, 4] = new Membership(BorderingGardens.Yellow);
		membership[14, 5] = new Membership(BorderingGardens.Yellow);
		membership[14, 6] = new Membership(BorderingGardens.Yellow);
		membership[14, 7] = new Membership(BorderingGardens.Yellow_White);
		membership[14, 8] = new Membership(BorderingGardens.White);
		membership[14, 9] = new Membership(BorderingGardens.White_Red);
		membership[14, 10] = new Membership(BorderingGardens.Red);
		membership[14, 11] = new Membership(BorderingGardens.Yellow_Red);
		membership[14, 12] = new Membership(BorderingGardens.Yellow);
		membership[14, 13] = new Membership(BorderingGardens.Yellow);
		membership[14, 14] = new Membership(BorderingGardens.Yellow);
		membership[14, 15] = new Membership(BorderingGardens.Yellow);
		membership[14, 16] = new Membership(BorderingGardens.Yellow);
		// P4-16
		membership[15, 3] = new Membership(BorderingGardens.Yellow);
		membership[15, 4] = new Membership(BorderingGardens.Yellow);
		membership[15, 5] = new Membership(BorderingGardens.Yellow);
		membership[15, 6] = new Membership(BorderingGardens.Yellow);
		membership[15, 7] = new Membership(BorderingGardens.Yellow);
		membership[15, 8] = new Membership(BorderingGardens.Yellow_White);
		membership[15, 9] = new Membership(BorderingGardens.White_Red);
		membership[15, 10] = new Membership(BorderingGardens.Yellow_Red);
		membership[15, 11] = new Membership(BorderingGardens.Yellow);
		membership[15, 12] = new Membership(BorderingGardens.Yellow);
		membership[15, 13] = new Membership(BorderingGardens.Yellow);
		membership[15, 14] = new Membership(BorderingGardens.Yellow);
		membership[15, 15] = new Membership(BorderingGardens.Yellow);
		// Q5-15
		membership[16, 4] = new Membership(BorderingGardens.Yellow);
		membership[16, 5] = new Membership(BorderingGardens.Yellow);
		membership[16, 6] = new Membership(BorderingGardens.Yellow);
		membership[16, 7] = new Membership(BorderingGardens.Yellow);
		membership[16, 8] = new Membership(BorderingGardens.Yellow);
		membership[16, 9] = new Membership(BorderingGardens.SouthTorii_Yellow_White_Red);
		membership[16, 10] = new Membership(BorderingGardens.Yellow);
		membership[16, 11] = new Membership(BorderingGardens.Yellow);
		membership[16, 12] = new Membership(BorderingGardens.Yellow);
		membership[16, 13] = new Membership(BorderingGardens.Yellow);
		membership[16, 14] = new Membership(BorderingGardens.Yellow);
		// R6-14
		membership[17, 5] = new Membership(BorderingGardens.Yellow);
		membership[17, 6] = new Membership(BorderingGardens.Yellow);
		membership[17, 7] = new Membership(BorderingGardens.Yellow);
		membership[17, 8] = new Membership(BorderingGardens.SouthTorii_Yellow);
		membership[17, 9] = new Membership(BorderingGardens.SouthTorii);
		membership[17, 10] = new Membership(BorderingGardens.SouthTorii_Yellow);
		membership[17, 11] = new Membership(BorderingGardens.Yellow);
		membership[17, 12] = new Membership(BorderingGardens.Yellow);
		membership[17, 13] = new Membership(BorderingGardens.Yellow);
		// S9-11
		membership[18, 8] = new Membership(BorderingGardens.SouthTorii);
		membership[18, 9] = new Membership(BorderingGardens.SouthTorii);
		membership[18, 10] = new Membership(BorderingGardens.SouthTorii);
		#endregion
	}

	// Update is called once per frame
	void Update ()
	{

	}

	public Membership GetMembership(int row, int column)
	{
		return membership[row, column];
	}

	public GameObject GetOccupation(int row, int column)
	{
		return occupation[row, column];
	}

	public void MovePiece(int sourceX, int sourceY, int destinationX, int destinationY)
	{
		if (occupation[destinationX, destinationY] != null)
		{
			Pieces.Remove((Piece)occupation[destinationX, destinationY].GetComponent(typeof(Piece)));
			DestroyImmediate(occupation[destinationX, destinationY]);
		}
		occupation[destinationX, destinationY] = occupation[sourceX, sourceY];
		occupation[sourceX, sourceY] = null;
	}

	public void DropPiece(int x, int y, GameObject piece)
	{
		occupation[x, y] = piece;
		Pieces.Add((Piece)piece.GetComponent(typeof(Piece)));
	}

	public List<Piece> GetPieces()
	{
		List<Piece> l = new List<Piece>();
		foreach (GameObject g in occupation)
		{
			if (g != null)
			{
				l.Add((Piece)g.GetComponent(typeof(Piece)));
			}
		}

		return l;
	}
}
