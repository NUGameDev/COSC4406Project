using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Diagnostics;
using System;

public class PufferManager : MonoBehaviour {
	public Transform Puff;
	public Vector3 ObjectSpawnPosition;
	public Slider Pufferslider;
	public float pufferIncrease = 10;
	private float CurrentPuffer;
	private float maxPuffer;
	BreathManager bm;
	// Use this for initialization
	void Start () {

		CurrentPuffer = Pufferslider.value;
		maxPuffer = Pufferslider.maxValue;
		bm = GetComponent<BreathManager>();

	}

	void Update () 	// Update is called once per frame
	{
		Pufferslider.value = CurrentPuffer;//Updates the slider with the current charge of the puffer
		if(Input.GetButtonDown("Fire1") && HasPuff() ) {//Condition to check if the user has pressed the button to restore breath and if they have a puffer charger ready to use to restore the breath.
			RestoreBreath();//Calls RestoreBreath
		}
		if(Input.GetButtonDown("Fire2") && HasPuff() ) {//Condition to check if the user has pressed the button to create a puffer cloud and if they have a puffer charger ready to use to create the cloud.
			AttackPuff();//Calls AttackPuff
		}
	}
	 void RestoreBreath(){//Function used to restore breath when called
		PufferUse();//Calls PufferUse
		bm.BreathPuffer();//Calls BreathPuffer from the BreathManager class
	}
	void PufferUse(){//Function used to reduce puffer charger by one use
		CurrentPuffer -= 1.0f;//Reduces Current Puffer by one
	}
	void AttackPuff(){//Function used to create puffer clouds
		PufferUse();//Calls Pufferuse
		Instantiate(Puff, new Vector3 (transform.position.x +1.5f,transform.position.y + 1.5f, transform.position.z), Quaternion.identity);//Instantiates an instance of a puffer cloud infront of the player.
	}
	public bool HasPuff(){//Function that returns if the puffer charger is create than zero
		return CurrentPuffer > 0.0f;//Returns true if puffer charger is greater than zero, returns false otheriwse
	}
	public void IncreasePuffer(){
		CurrentPuffer = Math.Max (CurrentPuffer + pufferIncrease, maxPuffer);
	}
}
