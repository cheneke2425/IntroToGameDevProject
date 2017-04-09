using UnityEngine;
using System.Collections;

public class SwitchPositions : MonoBehaviour
{	
	private GameObject firstObj = null;
	private GameObject secondObj = null;
	private Animator firstAnimator;
	private Animator secondAnimator;

	//bool firstClick = true;
	private Vector3 SelectedPos;
	private Vector3 firstObjPos;
	private Vector3 secondObjPos;

	public AudioClip PaddleSelected;
	public AudioClip PaddleDeSelected;
	public AudioClip PaddleSwap;

	private AudioSource source;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		source = GetComponent<AudioSource>();

		if (Input.GetMouseButtonDown(0))
		{
			SelectedPos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
									   Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
			RaycastHit2D hit = Physics2D.Raycast(SelectedPos, Vector2.zero, 0f);


			if (hit && hit.transform.gameObject.CompareTag("Paddle"))
			{
				if (firstObj == null)
				{
					firstObj = hit.transform.gameObject;
					firstObjPos = firstObj.transform.position;
					firstAnimator = firstObj.GetComponent<Animator>();
					firstAnimator.SetBool("OnSelect", true);

					source.PlayOneShot(PaddleSelected, 1f);
				}
				else if (firstObj == hit.transform.gameObject)
				{
					firstAnimator = firstObj.GetComponent<Animator>();
					firstAnimator.SetBool("OnSelect", false);
					firstObj = null;

					source.PlayOneShot(PaddleDeSelected, 1f);
				}
				else if (firstObj != null && firstObj != hit.transform.gameObject)
				{
					secondObj = hit.transform.gameObject;
					secondObjPos = secondObj.transform.position;
					secondAnimator = secondObj.GetComponent<Animator>();
					secondAnimator.SetBool("OnSelect", true);

					source.PlayOneShot(PaddleSelected, 1f);
				}
			}
		}

		if (firstObj != null && secondObj != null)
		{
			Swap();
		}
	}

	void Swap()
	{
		firstObj.transform.position = secondObjPos;
		secondObj.transform.position = firstObjPos;

		firstAnimator = firstObj.GetComponent<Animator>();
		secondAnimator = secondObj.GetComponent<Animator>();
		firstAnimator.SetBool("OnSelect", false);
		secondAnimator.SetBool("OnSelect", false);

		source.PlayOneShot(PaddleSwap, 1f);

		firstObj = null;
		secondObj = null;
	}
}
