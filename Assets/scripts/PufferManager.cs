using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Diagnostics;
using System;
public class PufferManager : MonoBehaviour {
	public Transform Puff;//game object used to hold the puffer cloud
	public Vector3 ObjectSpawnPosition;//Vector that the puffer cloud spawns at
	public Slider Pufferslider;//Slider object that displays current puffer charge
	private float CurrentPuffer;//Float that stores current puffer charge
	BreathManager bm;//Breath manager component
	void Start () {//Runs on startup
		CurrentPuffer = Pufferslider.value;// Sets the current puffer charge to the maximum
		bm = GetComponent<BreathManager>();//Gets the breath manager component
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
}
