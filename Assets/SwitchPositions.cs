using UnityEngine;
using System.Collections;

public class SwitchPositions : MonoBehaviour
{
	public GameObject firstObj;
	public GameObject secondObj;

	bool firstClick = true;
	private Vector3 SelectedPos;
	private Vector3 firstObjPos;
	private Vector3 secondObjPos;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			SelectedPos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
									   Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
			RaycastHit2D hit = Physics2D.Raycast(SelectedPos, Vector2.zero, 0f);

			if (hit && firstClick)
			{
				firstObj = hit.transform.gameObject;
				firstObjPos = firstObj.transform.position;
				firstClick = false;
			}
			else if (hit && !firstClick)
			{
				secondObj = hit.transform.gameObject;
				secondObjPos = secondObj.transform.position;

				firstObj.transform.position = secondObjPos;
				secondObj.transform.position = firstObjPos;

				firstClick = true;
			}
		}
	}
}
