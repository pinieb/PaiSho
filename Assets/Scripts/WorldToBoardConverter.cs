using UnityEngine;
using System.Collections;

public class WorldToBoardConverter : MonoBehaviour 
{
	public static Vector2 WorldToBoard(Vector3 worldPoint)
	{
		return new Vector2(worldPoint.y * 2 + 9, worldPoint.x * 2 + 9);
	}

	public static Vector2 WorldToBoard(Vector2 worldPoint)
	{
		return new Vector2(worldPoint.y * 2 + 9, worldPoint.x * 2 + 9);
	}

	public static Vector2 WorldToBoard(float worldPointX, float worldPointY)
	{
		return new Vector2(worldPointY * 2 + 9, worldPointX * 2 + 9);
	}
}
