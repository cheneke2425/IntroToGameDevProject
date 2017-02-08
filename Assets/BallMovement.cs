using UnityEngine;
using System.Collections;

public class BallMovement : MonoBehaviour {

	public float xSpeed = 0.1f;
	public float ySpeed = 0.1f;

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody2D>().velocity = new Vector3(xSpeed, ySpeed, 0);
	}
	
	// Update is called once per frame
	void Update () {


	}
}
