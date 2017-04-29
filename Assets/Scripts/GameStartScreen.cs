using UnityEngine.SceneManagement;
using System.Collections;

public class GameStartScreen : UnityEngine.MonoBehaviour
{


	public void StartPressed()
	{
		SceneManager.LoadScene("Level#1");
	}

	public void Level1Pressed()
	{
		SceneManager.LoadScene("Level#1");
	}

	public void Level2Pressed()
	{
		SceneManager.LoadScene("Level#2");
	}

}
