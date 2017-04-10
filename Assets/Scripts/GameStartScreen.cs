using UnityEngine;
using System.Collections;

public class GameStartScreen : MonoBehaviour {


	public void StartPressed()
	{
		Application.LoadLevel("Level#1");
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
