using UnityEngine;
using System.Collections;

public class WinLose : MonoBehaviour {


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);

		if (other.gameObject.CompareTag("Goal"))
		{
			Debug.Log("YOU WIN!");
		}
		else if (other.gameObject.CompareTag("Obstacle"))
		{
			Debug.Log("YOU LOSE!");
		}
	}
}
