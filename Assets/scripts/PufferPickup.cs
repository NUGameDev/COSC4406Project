using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class PufferPickup : MonoBehaviour {

	public float pufferRecharge = 20f;

	private PufferManager pm;
	private float yCenter;
	private float yMove;
	private float bobRange = 0.4f;
	private float bobSpeed = 0.7f;
	// Use this for initialization
	void Start () {
		pm = GameObject.Find ("Player").GetComponent<PufferManager> ();
		yCenter = transform.position.y;
		yMove = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (Math.Abs (yMove) > bobRange) {
			bobSpeed = -bobSpeed;
			yMove = Math.Sign (yMove) * bobRange;
		}
		yMove += Time.deltaTime * bobSpeed;
		transform.position = new Vector3 (transform.position.x, yCenter + yMove, transform.position.z);
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag ("Player"))
		{
			pm.IncreasePuffer();
			Destroy(gameObject);
		}
	}
}
