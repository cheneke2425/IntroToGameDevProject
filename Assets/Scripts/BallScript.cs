using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {

	public float xSpeed = 0.1f;
	public float ySpeed = 0.1f;

	public float xPos = -7f;
	public float yPos = -3.02f;

	public GameObject YouWin;

	private Animator animator;

	private float xValue;
	private float yValue;

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
				animator = hit.transform.gameObject.GetComponent<Animator>();
				animator.SetTrigger("OnClick");
				StartCoroutine(WaitForMovement());
			} 
		}

		xValue = GetComponent<Rigidbody2D>().velocity.x;
		yValue = GetComponent<Rigidbody2D>().velocity.y;

		if (GetComponent<Rigidbody2D>().velocity != new Vector2(0,0))
		{
			float angle = Mathf.Atan2(yValue, xValue) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis(angle+90, Vector3.forward);
		}

	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Paddle"))
		{
			GameObject paddle = other.gameObject;
			PaddleAudio paddleaudio = paddle.GetComponent<PaddleAudio>();
			paddleaudio.play();
		}

		if (other.gameObject.CompareTag("Goal"))
		{
			Win();
		}
		else if (other.gameObject.CompareTag("Obstacle"))
		{
			Lose();
		}
	}

	void Win()
	{
		GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
		Debug.Log("YOU WIN!");
		YouWin.transform.position = new Vector3(0, 0, 0);
	}

	void Lose()
	{
		GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
		Debug.Log("YOU LOSE!");
		StartCoroutine(WaitForRestart());
	}

	void Movement()
	{
		GetComponent<Rigidbody2D>().velocity = new Vector3(xSpeed, ySpeed, 0);
	}

	IEnumerator WaitForMovement()
	{
		yield return new WaitForSeconds(0.833f);
		Movement();
	}

	IEnumerator WaitForRestart()
	{
		yield return new WaitForSeconds(3);
		Application.LoadLevel ("Level#1");
	}

}
