using UnityEngine;
using System.Collections;

public class whenlevelloaded : MonoBehaviour {

	public Vector3 targetPos;
	public bool loaded = false;

	// Use this for initialization
	void Start () {

		transform.position = new Vector3(targetPos.x, targetPos.y + 10, targetPos.z);
		if (loaded == false)
		{
			StartCoroutine(EnterInSecond(1));
		}
	}
	
	// Update is called once per frame
	void Update () {

	}

	IEnumerator EnterInSecond(float second)
	{
		float StartEnteringTime = Time.time;
		while (Time.time - StartEnteringTime <= second)
		{
			float t = (Time.time - StartEnteringTime) / second;
			transform.position = new Vector3(targetPos.x, easeOutBack(targetPos.y + 10, targetPos.y, t), targetPos.z);
			yield return null;
		}

		transform.position = targetPos;

		loaded = true;
	}

	public float easeOutBack(float start, float end, float value)
	{
		float s = 1.70158f;
		end -= start;
		value = (value) - 1;
		return end * ((value) * value * ((s + 1) * value + s) + 1) + start;
	}
}
