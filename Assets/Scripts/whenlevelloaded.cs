using UnityEngine;
using System.Collections;

public class whenlevelloaded : MonoBehaviour {

	public GameObject character;
	public Vector3 targetPos;
	public bool loaded = false;

	public GameObject paddle1 = null;
	public GameObject paddle2 = null;
	public GameObject paddle3 = null;


	// Use this for initialization
	void Start () {

		if (paddle1 != null && paddle2 != null && paddle3 != null)
		{
			paddle1.transform.GetChild(0).gameObject.layer = LayerMask.NameToLayer("Default");
			paddle2.transform.GetChild(0).gameObject.layer = LayerMask.NameToLayer("Default");
			paddle3.transform.GetChild(0).gameObject.layer = LayerMask.NameToLayer("Default");
		}

		character.GetComponent<BallScript>().enabled = false;
		character.GetComponent<SwitchPositions>().enabled =false;

		transform.position = new Vector3(targetPos.x, targetPos.y + 10, targetPos.z);
		if (loaded == false)
		{
			StartCoroutine(EnterInSecond(1));
		}
	}
	
	// Update is called once per frame
	void Update () {

		if (loaded)
		{
			character.GetComponent<BallScript>().enabled = true;
			character.GetComponent<SwitchPositions>().enabled = true;
		}
		else {
			character.GetComponent<BallScript>().enabled = false;
			character.GetComponent<SwitchPositions>().enabled = false;
		}

	}

	IEnumerator EnterInSecond(float second)
	{
		float StartEnteringTime = Time.time;
		while (Time.time - StartEnteringTime <= second)
		{
			character.transform.localPosition = Vector3.zero;
			float t = (Time.time - StartEnteringTime) / second;
			transform.position = new Vector3(targetPos.x, easeOutBack(targetPos.y + 10, targetPos.y, t), targetPos.z);
			yield return null;
		}

		transform.position = targetPos;
		character.transform.localPosition = Vector3.zero;

		loaded = true;
	}

	public IEnumerator ExitInSecond(float second)
	{
		loaded = false;

		float StartEnteringTime = Time.time;
		while (Time.time - StartEnteringTime <= second)
		{
			float t = (Time.time - StartEnteringTime) / second;
			transform.position = new Vector3(0, easeInBack(0, -10, t), 0);
			yield return null;
		}

	}

	public float easeOutBack(float start, float end, float value)
	{
		float s = 1.70158f;
		end -= start;
		value = (value) - 1;
		return end * ((value) * value * ((s + 1) * value + s) + 1) + start;
	}

	public float easeInBack(float start, float end, float value)
	{
		end -= start;
		value /= 1;
		float s = 1.70158f;
		return end * (value) * value * ((s + 1) * value - s) + start;
	}
}
