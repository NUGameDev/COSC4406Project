using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ProgressScript : MonoBehaviour 
{
	public float startPos = 0.0f;	//placeholders for start and end points
	public float endPos = 100.0f;	//will need GameObjects for these positions in each level
	//public float playerPos = 0.0f;	//for testing

	private float barWidth;			//Width of progress bar
	private float factor;			//Factor for interpolating position on bar
	private Transform player;		//Position of Player object
	private RectTransform progressCircle;	//RectTransform component of current Object
	public RectTransform progressBar;		//RectTransform component of parent Object

	void Start () 
	{
		//Get components
		player = GameObject.Find("Player").transform;	//Player must be Tagged
		progressCircle = GetComponent<RectTransform> ();
		//progressBar = GetComponentInParent (RectTransform); //Get component from parent
		float circleWidth = progressCircle.rect.width;		//Width of circle 
		factor = (progressBar.rect.width - (circleWidth)) / (endPos - startPos);	//For interpolating
	}

	//Each frame, the player position is used to set the position on the progress bar
	void Update () 
	{
		progressCircle.anchoredPosition = new Vector3((player.position.x /*playerPos*/ - startPos) * factor, 0f, 0f);
	}
}
