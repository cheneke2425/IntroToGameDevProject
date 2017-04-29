using UnityEngine;
using System.Collections;

public class aspectRatio : MonoBehaviour
{

	// Use this for initialization
	void Start()
	{

		float targetaspect = 750f / 1334f;

		float windowaspect = (float)Screen.width / (float)Screen.height;

		float scaleheight = windowaspect / targetaspect;

		Camera cam = GetComponent<Camera>();

		if (scaleheight < 1.0f)
		{
			Rect rect = cam.rect;

			rect.width = 1.0f;
			rect.height = scaleheight;
			rect.x = 0;
			rect.y = (1.0f - scaleheight) / 2.0f;

			cam.rect = rect;
		}
		else
		{
			float scalewidth = 1.0f / scaleheight;

			Rect rect = cam.rect;

			rect.width = scalewidth;
			rect.height = 1.0f;
			rect.x = (1.0f - scalewidth) / 2.0f;
			rect.y = 0;

			cam.rect = rect;
		}
	}
}