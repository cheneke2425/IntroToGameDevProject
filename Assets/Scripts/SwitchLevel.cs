using UnityEngine.SceneManagement;
using System.Collections;

public class SwitchLevel : UnityEngine.MonoBehaviour
{

	public int nextLevel;
	public int thisLevel;

	public void NextLevelButtonPressed()
	{
		SceneManager.LoadScene("Level#" + nextLevel);
	}

	public void ReplayLevelBUttonPressed()
	{
		SceneManager.LoadScene("Level#" + thisLevel);
	}

	public void WhenLoseGame()
	{
		SceneManager.LoadScene("Level#" + thisLevel);
	}

	public void MainMenuButtonPressed()
	{
		SceneManager.LoadScene("StartScene");
	}
}
