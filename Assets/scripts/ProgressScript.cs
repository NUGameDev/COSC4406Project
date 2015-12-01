using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ProgressScript : MonoBehaviour 
{

	public float startPos = 0.0f;
	public float endPos = 100.0f;
	public RectTransform progressCircle;
	public RectTransform progressBar;

	public float playerPos = 0.0f;	//for testing

	private float barWidth;
	private float factor;
	//private Transform player;

	void Awake () 
	{
		//player = GameObject.FindGameObjectWithTag ("Player").transform;
		progressCircle = GetComponent<RectTransform> ();
		float circleWidth = progressCircle.rect.width;
		factor = (progressBar.rect.width - (circleWidth/2)) / (endPos - startPos);
	}

	void Update () 
	{
		progressCircle.anchoredPosition = new Vector3((/*player.position.x*/playerPos - startPos) * factor, 0f, 0f);
	}
}
