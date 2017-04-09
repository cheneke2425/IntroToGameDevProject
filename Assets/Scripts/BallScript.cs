using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {

	public float xSpeed = 0.1f;
	public float ySpeed = 0.1f;

	public float xPos = -7f;
	public float yPos = -3.02f;

	public GameObject YouWin;

	// Use this for initialization
	void Start () {

		transform.position = new Vector3(xPos, yPos, 0);
	
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 SelectedPos;

		if (Input.GetMouseButtonDown(0))
		{
			SelectedPos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
									   Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
			RaycastHit2D hit = Physics2D.Raycast(SelectedPos, Vector2.zero, 0f);

			if (hit && hit.transform.gameObject.CompareTag("Replay"))
			{
				Start();
				GetComponent<Rigidbody2D>().velocity = new Vector3(xSpeed, ySpeed, 0);
			} 
		}
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{

		if (other.gameObject.CompareTag("Goal"))
		{
			GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
			Debug.Log("YOU WIN!");
			YouWin.transform.position = new Vector3(0, 0, 0);
		}
		else if (other.gameObject.CompareTag("Obstacle"))
		{
			GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
			Debug.Log("YOU LOSE!");
		}
	}

}
