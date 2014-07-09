using UnityEngine;
using System.Collections;

public class BoardInitializer : MonoBehaviour
{
	public GameObject PlaceHolder;

	private float BoardWidth = 4.6f;

	// Use this for initialization
	void Start ()
	{
		// Create all the placement objects
		// what a nightmare :P

		bool[,] intersections = new bool[19, 19];
		// populate a list of valid intersections
		for (int i = 0; i < 19; i++)
		{
			for (int j = 0; j < 19; j++)
			{
				float x = j * .5f - 4.5f;
				float y = i * .5f - 4.5f;

				if (Mathf.Sqrt(Mathf.Pow(x, 2) + Mathf.Pow(y, 2)) <= BoardWidth)
				{
					intersections[i, j] = true;

					GameObject position = (GameObject)Instantiate(PlaceHolder, new Vector3(x, y, 0f), Quaternion.identity);
					position.transform.parent = transform;
					position.tag = "Intersection";
					position.name = ((Row)i).ToString() + (j + 1);
				}
			}
		}
	}

	// Update is called once per frame
	void Update ()
	{

	}
}
