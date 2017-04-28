using UnityEngine;
using System.Collections;

public class backnforthmovement : MonoBehaviour {

	public float speed;
	public float tolerance;
	public Vector3 startPos;
	public Vector3 endPos;
	private Vector3 target;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		// Get current position
		float curYPos = transform.position.y;

		// Move between the start and end vectors
		if (isApproximate(curYPos, endPos.y, tolerance))
		{
			target = startPos;
		}
		else if (isApproximate(curYPos, startPos.y, tolerance))
		{
			target = endPos;
		}

		// Update position
		transform.position = Vector3.Lerp(transform.position, target, speed * Time.deltaTime);

	}

	bool isApproximate(float a, float b, float t)
	{
		return Mathf.Abs(a - b) < t;
	}
}
