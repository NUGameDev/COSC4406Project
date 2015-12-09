using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PufferPickup : MonoBehaviour {

	public PufferManager pm;
	public float pufferRecharge = 20f;
	private float yCenter;
	// Use this for initialization
	void Start () {
		yCenter = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
	
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
