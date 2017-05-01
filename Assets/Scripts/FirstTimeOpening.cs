using UnityEngine;
using System.Collections;

public class FirstTimeOpening : MonoBehaviour {


	// Use this for initialization
	void Start () {

		if (PlayerPrefs.GetInt("FIRSTTIMEOPENING", 1) == 1)
		{
			Debug.Log("First Time Opening");

			PlayerPrefs.SetInt("FIRSTTIMEOPENING", 0);

			GameObject tutorial = GameObject.Find("Tutorials");
			tutorial.SetActive(true);

		}
		else
		{
			Debug.Log("NOT First Time Opening");

			GameObject tutorial = GameObject.Find("Tutorials");
			tutorial.SetActive(false);
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
