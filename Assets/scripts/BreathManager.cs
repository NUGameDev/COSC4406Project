using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Diagnostics;
using System;

public class BreathManager : MonoBehaviour {
    public Slider breathslider;//Silder used to display current breath
    private float currentbreath;//Variable that holds the current breath
    public float jumpDepletionRate = 0.0f;//Variable that holds the amount of breath used to jump
	public float runDepletionRate = 0.0f;//Variable that holds the amount of breath used while running
    public long recoveryWait = 0;//Amount of time the player must be still before breath begins to recover
    public float recoveryRate = 0.0f;//Amount the breath recovers while waiting
    public float pufferBreath = 0.0f;//Amount of breath using the puffer restores

    Stopwatch recoveryTimer = new Stopwatch();//Stopwatch used to determine if the user has been waiting long enough.
    MovementManager mm;
	ConfigManager cm;
    void Start () {//Runs on scene load
		string fromconfig;
		cm = GetComponent<ConfigManager> ();//Gets the ConfigManager
        mm = GetComponent<MovementManager>();//Gets the movementmanager 
        currentbreath = breathslider.value;//Sets the breath slider to the current breath
        recoveryTimer.Start();//Starts the recovery timer

		//Up coming block populates the variables from the config file
		fromconfig = cm.Load("jumpDepletionRate");
		jumpDepletionRate = (float)Int32.Parse(fromconfig);
		fromconfig = cm.Load("runDepletionRate");
		runDepletionRate = (float)Int32.Parse(fromconfig);
		fromconfig = cm.Load("recoveryWait");
		recoveryWait = (long)Int32.Parse(fromconfig);
		fromconfig = cm.Load("recoveryRate");
		recoveryRate = (float)Int32.Parse(fromconfig);
		fromconfig = cm.Load("pufferBreath");
		pufferBreath = (float)Int32.Parse(fromconfig);
		//end of populate
	}
	

	void Update ()	// Update is called once per frame
    {
        // Idle breath recovery
        if (mm.IsMoving())//Checks if the player is moving
        {
            recoveryTimer.Reset();//Resets the recovery timer
            recoveryTimer.Start();//Starts the recovery timer
        }
        if (recoveryTimer.ElapsedMilliseconds > recoveryWait)//Checks if the player has been waiting long enough
        {
            currentbreath = Math.Min(currentbreath + Time.deltaTime * recoveryRate, breathslider.maxValue);//increases the players breath by the recovery rate, or to the max which ever is a smaller increase
        }
        // running Breath Depletion
        if (mm.IsRunning())//Checks if the player is running
        {
			currentbreath = Math.Max(breathslider.minValue, currentbreath - Time.deltaTime * runDepletionRate);//decreases the players breath by the run depletion rat, or to the min which ever is a smaller increase
		}
		
		breathslider.value = currentbreath;//Updates the slider to the current breath
    }
    public void BreathJump()//method used to drease breath when jumping    
	{
        currentbreath -= jumpDepletionRate;//decrease breath after jump
    }

    public void BreathPuffer()//method used to increase breath when the puffer is used
    {
        currentbreath = Math.Min(breathslider.maxValue, currentbreath + pufferBreath);//increases the puffer to the max or by the amount the puffer should restore, which ever is smaller.
    }

    public bool CanJump()//method used to check if the player can jump
    {
        return currentbreath >= jumpDepletionRate;//returns true if the player has enough breath to jump, and false if they do not.
    }
}
