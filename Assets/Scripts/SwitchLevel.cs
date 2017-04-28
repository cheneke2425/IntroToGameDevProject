using UnityEngine;
using System.Collections;

public class SwitchLevel : MonoBehaviour {

	public int nextLevel;

	public void NextLevelButtonPressed()
	{
		Application.LoadLevel("Level#"+nextLevel);
	}
}
