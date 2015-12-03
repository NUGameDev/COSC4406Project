using UnityEngine;
using System.Collections;

public class Delete : MonoBehaviour {
	public double Lifetime;
	// Use this for initialization
	void Start () {
		Lifetime = Time.time + 2;
	}
	
	// Update is called once per frame
	void Update () {
		if (Lifetime < Time.time)
			Destroy (gameObject);
	}
}
