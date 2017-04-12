using UnityEngine;
using System.Collections;

public class dontdestroyonload : MonoBehaviour {

	public static bool haveLoadedAudioManager = false;

	// Use this for initialization
	void Start()
	{
		if (haveLoadedAudioManager)
		{
			Destroy(gameObject);
		}
		else {
			DontDestroyOnLoad(gameObject);
			haveLoadedAudioManager = true;
		}

	}
}
