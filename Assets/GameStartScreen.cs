using UnityEngine;
using System.Collections;

public class GameStartScreen : MonoBehaviour {

	public GameObject menu;
	public GameObject levelSelection;
	public float xPos = -799f;
	public float yPos = 328f;
	public float XPos = 0f;
	public float YPos = 0f;


	public void StartPressed()
	{
		Vector3 otherPos = new Vector3(xPos, yPos, 0);
		Vector3 newPos = new Vector3(XPos, YPos, 0);

		menu.transform.position = otherPos;
		levelSelection.transform.position = newPos;

	}

	public void Level1Pressed()
	{
		Application.LoadLevel("Level#1");
	}

	public void Level2Pressed()
	{
		Application.LoadLevel("Level#2");
	}

}
