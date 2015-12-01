using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PufferManager : MonoBehaviour {
	public Transform Puff;
	public Vector3 ObjectSpawnPosition;
	public Slider Pufferslider;
	private float CurrentPuffer;
	BreathManager bm;
	// Use this for initialization
	void Start () {

		CurrentPuffer = Pufferslider.value;
		bm = GetComponent<BreathManager>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		Pufferslider.value = CurrentPuffer;
		if(Input.GetButtonDown("Fire1") && HasPuff() ) {
			RestoreBreath();
		}
		if(Input.GetButtonDown("Fire2") && HasPuff() ) {
			AttackPuff();
		}
	}
	void RestoreBreath(){
		PufferUse();
		bm.BreathPuffer();
	}
	void PufferUse(){
		CurrentPuffer -= 1.0f;
	}
	void AttackPuff(){
		PufferUse();
		Instantiate(Puff, new Vector3 (transform.position.x +1.5f,transform.position.y + 1.5f, transform.position.z), Quaternion.identity);
	}
	public bool HasPuff(){
		return CurrentPuffer > 0.0f;
	}
}
