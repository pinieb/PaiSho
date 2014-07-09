using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	public BoardManager boardManager;
	public int Score;
	public int Id;
	public string Name;

	public void UpdateScore()
	{
		Score = 0;
		foreach (Piece p in boardManager.Pieces)
		{
			if (p.Owner == this)
			{
				Score += p.Harmony;
			}
		}

		//Debug.Log(Id + " " + Score);
	}

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		UpdateScore();
	}
}
