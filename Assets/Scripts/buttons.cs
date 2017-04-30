using UnityEngine;
using System.Collections;

public class buttons : MonoBehaviour {

	private Vector3 SelectedPos;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetMouseButtonDown(0))
		{
			SelectedPos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
									   Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
			RaycastHit2D hit = Physics2D.Raycast(SelectedPos, Vector2.zero, 0f);

			if (hit.transform.gameObject.CompareTag("Replay"))
			{
				StartCoroutine(ReplayInSecond(1));
			}
			else if (hit.transform.gameObject.CompareTag("NextLevel"))
			{
				StartCoroutine(ProceedInSecond(1));
			}
			else if (hit.transform.gameObject.CompareTag("MainMenu"))
			{
				GameObject restart = GameObject.Find("SwitchLevel");
				SwitchLevel switchLevel = restart.GetComponent<SwitchLevel>();
				switchLevel.MainMenuButtonPressed();
			}
		}
	
	}

	IEnumerator ProceedInSecond(float second)
	{
		float StartEnteringTime = Time.time;
		while (Time.time - StartEnteringTime <= second)
		{
			float t = (Time.time - StartEnteringTime) / second;
			transform.position = new Vector3(0, easeInBack(0, -10, t), 0);
			yield return null;
		}

		GameObject restart = GameObject.Find("SwitchLevel");
		SwitchLevel switchLevel = restart.GetComponent<SwitchLevel>();
		switchLevel.NextLevelButtonPressed();
	}

	IEnumerator ReplayInSecond(float second)
	{
		float StartEnteringTime = Time.time;
		while (Time.time - StartEnteringTime <= second)
		{
			float t = (Time.time - StartEnteringTime) / second;
			transform.position = new Vector3(0, easeInBack(0, -10, t), 0);
			yield return null;
		}

		GameObject restart = GameObject.Find("SwitchLevel");
		SwitchLevel switchLevel = restart.GetComponent<SwitchLevel>();
		switchLevel.ReplayLevelBUttonPressed();
	}

	public float easeInBack(float start, float end, float value)
	{
		end -= start;
		value /= 1;
		float s = 1.70158f;
		return end * (value) * value * ((s + 1) * value - s) + start;
	}
}
