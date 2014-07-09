using UnityEngine;
using System.Collections;

public class CountUpdater : MonoBehaviour 
{
	public PieceDropper dropper;

	private TextMesh text;
	
	void Start()
	{
		text = (TextMesh)gameObject.GetComponent(typeof(TextMesh));
		text.text = dropper.Available.ToString();
	}

	void Update()
	{
		text.text = dropper.Available.ToString();
	}
}
