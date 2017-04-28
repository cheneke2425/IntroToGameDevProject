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
					firstAnimator = firstObj.GetComponent<Animator>();
					firstAnimator.SetBool("OnSelect", true);

					source.PlayOneShot(PaddleSelected, 0.5f);
				}
				else if (firstObj == hit.transform.gameObject)
				{
					firstAnimator = firstObj.GetComponent<Animator>();
					firstAnimator.SetBool("OnSelect", false);
					firstObj = null;

					source.PlayOneShot(PaddleDeSelected, 0.5f);
				}
				else if (firstObj != null && firstObj != hit.transform.gameObject)
				{
					secondObj = hit.transform.gameObject;
					secondAnimator = secondObj.GetComponent<Animator>();
					secondAnimator.SetBool("OnSelect", true);

					//source.PlayOneShot(PaddleSelected, 0.5f);
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
		firstAnimator = firstObj.GetComponent<Animator>();
		secondAnimator = secondObj.GetComponent<Animator>();
		firstAnimator.SetBool("OnSelect", false);
		secondAnimator.SetBool("OnSelect", false);

		StartCoroutine(SwapInSecond(0.7f, firstObj, secondObj));

		source.PlayOneShot(PaddleSwap, 0.5f);

		firstObj = null;
		secondObj = null;

	}

	IEnumerator SwapInSecond(float second, GameObject fObj, GameObject sedObj)
	{
		float startSwapTime = Time.time;
		Vector3 firstObjStartPos = fObj.transform.position;
		Vector3 secondObjStartPos = sedObj.transform.position;
		while (Time.time - startSwapTime <= second)
		{
			float t = (Time.time - startSwapTime)/second;
			t = Mathf.Sin(t * Mathf.PI / 2f);

			fObj.transform.position = Vector3.Lerp(firstObjStartPos, secondObjStartPos, t);
			sedObj.transform.position = Vector3.Lerp(secondObjStartPos, firstObjStartPos, t);
			yield return null;
		}
		fObj.transform.position = secondObjStartPos;
		sedObj.transform.position = firstObjStartPos;
	}

}
