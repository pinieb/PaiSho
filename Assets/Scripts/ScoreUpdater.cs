using UnityEngine;
using System.Collections;

public class ScoreUpdater : MonoBehaviour 
{
	public Player player;
	private GUIText text;
	// Use this for initialization
	void Start () 
	{
		text = (GUIText)gameObject.GetComponent(typeof(GUIText));
		text.text = player.Name + ": " + player.Score.ToString();
	}
	
	// Update is called once per frame
	void Update () 
	{
		text.text = player.Name + ": " + player.Score.ToString();
	}
}
