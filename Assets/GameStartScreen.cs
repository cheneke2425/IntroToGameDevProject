using UnityEngine;
using System.Collections;

public class GameStartScreen : MonoBehaviour {

	public GameObject menu;
	public GameObject levelSelection;
	public float xPos = -799f;
	public float yPos = 328f;
	public float smoothTime = 0.3f;

	public void StartPressed()
	{
		Vector3 menuPos = menu.transform.position;
		Vector3 levelPos = levelSelection.transform.position;
		Vector3 otherPos = new Vector3(xPos, yPos, 0);
		Vector3 velocity = Vector3.zero;

		menu.transform.position = Vector3.SmoothDamp(menuPos, otherPos, ref velocity, smoothTime);
		levelSelection.transform.position = Vector3.SmoothDamp(levelPos, menuPos, ref velocity, smoothTime);

	}

	public void Level1Pressed()
	{
		Application.LoadLevel("Level#1");
	}


}
