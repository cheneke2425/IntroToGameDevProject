using UnityEngine;
using System.Collections;

public class SwitchLevel : MonoBehaviour {

	public void NextLevelButtonPressed()
	{
		Application.LoadLevel("Level#2");
	}
}
