using UnityEngine;
using System.Collections;

public enum BorderingGardens
{
	EastTorii,
	SouthTorii,
	WestTorii,
	NorthTorii,
	Yellow,
	White,
	Red,
	// Combinations
	EastTorii_Yellow,
	EastTorii_Yellow_White_Red,
	SouthTorii_Yellow,
	SouthTorii_Yellow_White_Red,
	WestTorii_Yellow,
	WestTorii_Yellow_White_Red,
	NorthTorii_Yellow,
	NorthTorii_Yellow_White_Red,
	Yellow_Red,
	Yellow_White,
	White_Red
}

public class Membership
{
	public bool EastTorii
	{
		get;
		private set;
	}
	public bool SouthTorii
	{
		get;
		private set;
	}
	public bool NorthTorii
	{
		get;
		private set;
	}
	public bool WestTorii
	{
		get;
		private set;
	}
	public bool YellowGarden
	{
		get;
		private set;
	}
	public bool WhiteGarden
	{
		get;
		private set;
	}
	public bool RedGarden
	{
		get;
		private set;
	}
	public bool Torii
	{
		get
		{
			return EastTorii || WestTorii || NorthTorii || SouthTorii;
		}
	}
	public bool Neutral
	{
		get
		{
			return (YellowGarden || Torii);
		}
	}
	public bool OnlyYellow
	{
		get
		{
			return YellowGarden && !Torii && !RedGarden && !WhiteGarden;
		}
	}

	public Membership ()
	{
	}

	public Membership (bool east, bool south, bool west, bool north, bool yellow, bool white, bool red)
	{
			EastTorii = east;
			SouthTorii = south;
			WestTorii = west;
			NorthTorii = north;
			YellowGarden = yellow;
			WhiteGarden = white;
			RedGarden = red;
	}

	public Membership(BorderingGardens b)
	{
		if (b == BorderingGardens.EastTorii || b == BorderingGardens.EastTorii_Yellow || b == BorderingGardens.EastTorii_Yellow_White_Red)
		{
			EastTorii = true;
		}

		if (b == BorderingGardens.SouthTorii || b == BorderingGardens.SouthTorii_Yellow || b == BorderingGardens.SouthTorii_Yellow_White_Red)
		{
			SouthTorii = true;
		}

		if (b == BorderingGardens.WestTorii || b == BorderingGardens.WestTorii_Yellow || b == BorderingGardens.WestTorii_Yellow_White_Red)
		{
			WestTorii = true;
		}

		if (b == BorderingGardens.NorthTorii || b == BorderingGardens.NorthTorii_Yellow || b == BorderingGardens.NorthTorii_Yellow_White_Red)
		{
			NorthTorii = true;
		}

		if (b == BorderingGardens.Yellow || b == BorderingGardens.EastTorii_Yellow || b == BorderingGardens.EastTorii_Yellow_White_Red || b == BorderingGardens.NorthTorii_Yellow ||
		    b == BorderingGardens.NorthTorii_Yellow_White_Red || b == BorderingGardens.SouthTorii_Yellow || b == BorderingGardens.SouthTorii_Yellow_White_Red || 
		    b == BorderingGardens.WestTorii_Yellow || b == BorderingGardens.WestTorii_Yellow_White_Red || b == BorderingGardens.Yellow_Red || b == BorderingGardens.Yellow_White)
		{
			YellowGarden = true;
		}

		if (b == BorderingGardens.White || b == BorderingGardens.EastTorii_Yellow_White_Red || b == BorderingGardens.NorthTorii_Yellow_White_Red || 
		    b == BorderingGardens.SouthTorii_Yellow_White_Red || b == BorderingGardens.WestTorii_Yellow_White_Red ||
		    b == BorderingGardens.White_Red || b == BorderingGardens.Yellow_White)
		{
			WhiteGarden = true;
		}

		if (b == BorderingGardens.Red || b == BorderingGardens.EastTorii_Yellow_White_Red || b == BorderingGardens.NorthTorii_Yellow_White_Red || 
		    b == BorderingGardens.SouthTorii_Yellow_White_Red || b == BorderingGardens.WestTorii_Yellow_White_Red ||
		    b == BorderingGardens.White_Red || b == BorderingGardens.Yellow_Red)
		{
			RedGarden = true;
		}
	}

	public static bool InSameGarden(Membership m1, Membership m2)
	{
		return ((m1.RedGarden && m2.RedGarden) || (m1.WhiteGarden && m2.WhiteGarden) || (m1.Neutral && m2.Neutral));
	}

	public bool IsWall()
	{
		if (YellowGarden && (RedGarden || WhiteGarden) && !(EastTorii || WestTorii || NorthTorii || SouthTorii))
		{
			return true;
		}

		return false;
	}
}
