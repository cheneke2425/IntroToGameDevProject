using UnityEngine;
using System.Collections;

public class backnforthmovement : MonoBehaviour
{
	public float tolerance;
	public Vector3 startPos;
	public Vector3 endPos;
	public float t = 0.05f;
	private Vector3 target;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		GameObject objs = GameObject.Find("AllObjs");
		whenlevelloaded whenloaded = objs.GetComponent<whenlevelloaded>();

		if (whenloaded.loaded)
		{
			float curYPos = transform.position.y;

			if (isApproximate(curYPos, endPos.y, tolerance))
			{
				target = startPos;
			}
			else if (isApproximate(curYPos, startPos.y, tolerance))
			{
				target = endPos;
			}

			transform.position = new Vector3(easeOutExpo(transform.position.x, target.x, t), easeOutExpo(transform.position.y, target.y, t), transform.position.z);

		}

	}

	bool isApproximate(float a, float b, float tol)
	{
		return Mathf.Abs(a - b) < tol;
	}

	public float easeOutExpo(float start, float end, float value)
	{
		end -= start;
		return end * (-Mathf.Pow(2, -10 * value) + 1) + start;
	}
}
