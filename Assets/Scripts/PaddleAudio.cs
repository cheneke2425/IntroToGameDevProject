using UnityEngine;
using System.Collections;

public class PaddleAudio : MonoBehaviour {

	public AudioClip bouncing;

	private AudioSource source;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void play()
	{
		gameObject.GetComponent<AudioSource>().PlayOneShot(bouncing, 1f);
	}
}
