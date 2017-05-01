using UnityEngine;
using System.Collections;

public class TutorialScript : MonoBehaviour {

	public GameObject character;
	public GameObject paddle1;
	public GameObject paddle2;
	public GameObject paddle3;

	public GameObject fstT;
	public GameObject secT;
	public GameObject thdT;

	public Vector3 firstTPos;
	public Vector3 secondTPos;
	public Vector3 thirdTPos;

	private int tutorialNumber = 0;
	private float tolerance = 0.01f;

	// Use this for initialization
	void Start () {

		paddle1.transform.GetChild(0).gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
		paddle2.transform.GetChild(0).gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
		paddle3.transform.GetChild(0).gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");

		transform.position = new Vector3(0, 0, 0);
		fstT.transform.localPosition = new Vector3(firstTPos.x, firstTPos.y + 10, firstTPos.z);
		secT.transform.localPosition = new Vector3(secondTPos.x, secondTPos.y + 10, secondTPos.z);
		thdT.transform.localPosition = new Vector3(thirdTPos.x, thirdTPos.y + 10, thirdTPos.z);

		StartCoroutine(TutorialStartsInSecond(fstT, firstTPos));

	}
	
	// Update is called once per frame
	void Update () {

		if (isApproximate(fstT.transform.localPosition.y, firstTPos.y, tolerance))
		{
			tutorialNumber = 1;
		}
		else if (isApproximate(secT.transform.localPosition.y, secondTPos.y, tolerance))
		{
			tutorialNumber = 2;
		}
		else if (isApproximate(thdT.transform.localPosition.y, thirdTPos.y, tolerance))
		{
			tutorialNumber = 3;
		}

		if (tutorialNumber == 1)
		{
			if (character.GetComponent<BallScript>().enabled)
			{
				character.GetComponent<BallScript>().enabled = false;
			}

			paddle1.transform.GetChild(0).gameObject.layer = LayerMask.NameToLayer("Default");
			paddle2.transform.GetChild(0).gameObject.layer = LayerMask.NameToLayer("Default");

			if (character.GetComponent<SwitchPositions>().SwapIsCalled)
			{
				StartCoroutine(ExitInSecond(1, fstT, firstTPos));
				StartCoroutine(TutorialStartsInSecond(secT, secondTPos));
			}

		} else if (tutorialNumber == 2)
		{
			character.GetComponent<BallScript>().enabled = false;

			paddle1.transform.GetChild(0).gameObject.layer = LayerMask.NameToLayer("Default");
			paddle2.transform.GetChild(0).gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
			paddle3.transform.GetChild(0).gameObject.layer = LayerMask.NameToLayer("Default");

			if (character.GetComponent<SwitchPositions>().SwapIsCalled)
			{
				StartCoroutine(ExitInSecond(1, secT, secondTPos));
				StartCoroutine(TutorialStartsInSecond(thdT, thirdTPos));
			}

		} else if (tutorialNumber == 3)
		{
			character.GetComponent<BallScript>().enabled = true;

			paddle1.transform.GetChild(0).gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
			paddle2.transform.GetChild(0).gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
			paddle3.transform.GetChild(0).gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");

			Vector3 checkVelocity = character.GetComponent<Rigidbody2D>().velocity;

			if ( checkVelocity != Vector3.zero)
			{
				StartCoroutine(ExitInSecond(1, thdT, thirdTPos));
			}
		}
	
	}

	bool isApproximate(float a, float b, float tol)
	{
		return Mathf.Abs(a - b) < tol;
	}

	IEnumerator TutorialStartsInSecond(GameObject tutorial, Vector3 target)
	{
		yield return new WaitForSeconds(1);
		StartCoroutine(EnterInSecond(1, tutorial, target));
	}

	IEnumerator EnterInSecond(float second, GameObject tutorial, Vector3 target)
	{
		float StartEnteringTime = Time.time;
		while (Time.time - StartEnteringTime <= second)
		{
			float t = (Time.time - StartEnteringTime) / second;
			tutorial.transform.localPosition= new Vector3(target.x, easeOutBack(target.y + 15, target.y, t), target.z);
			yield return null;
		}
	}

	IEnumerator ExitInSecond(float second, GameObject tutorial, Vector3 target)
	{
		float StartEnteringTime = Time.time;
		while (Time.time - StartEnteringTime <= second)
		{
			float t = (Time.time - StartEnteringTime) / second;
			tutorial.transform.localPosition = new Vector3(target.x, easeInBack(target.y, target.y - 15, t), target.z);
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
