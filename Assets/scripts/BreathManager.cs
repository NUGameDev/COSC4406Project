using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Diagnostics;
using System;

public class BreathManager : MonoBehaviour {
    public Slider breathslider;//Silder used to display current breath
    private float currentbreath;//Variable that holds the current breath
    public float jumpDepletionRate = 5.0f;//Variable that holds the amount of breath used to jump
    public float runDepletionRate = 1.0f;//Variable that holds the amount of breath used while running
    public long recoveryWait = 2000;//Amount of time the player must be still before breath begins to recover
    public float recoveryRate = 1f;//Amount the breath recovers while waiting
    public float pufferBreath = 25.0f;//Amount of breath using the puffer restores

    Stopwatch recoveryTimer = new Stopwatch();
    MovementManager mm;
    // Use this for initialization
    void Start () {
        mm = GetComponent<MovementManager>();
        currentbreath = breathslider.value;
        recoveryTimer.Start();
	}
	
	// Update is called once per frame
	void Update ()
    {
        // Idle breath recovery
        if (mm.IsMoving())
        {
            recoveryTimer.Reset();
            recoveryTimer.Start();
        }
        if (recoveryTimer.ElapsedMilliseconds > recoveryWait)
        {
            currentbreath = Math.Min(currentbreath + Time.deltaTime * recoveryRate, breathslider.maxValue);
        }
        // running Breath Depletion
        if (mm.IsRunning())
        {
            currentbreath = Math.Max(breathslider.minValue, currentbreath - Time.deltaTime * runDepletionRate);
        }

        breathslider.value = currentbreath;
    }
    public void BreathJump()
    {
        currentbreath -= jumpDepletionRate;
    }

    public void BreathPuffer()
    {
        currentbreath = Math.Min(breathslider.maxValue, currentbreath + pufferBreath);
    }

    public bool CanJump()
    {
        return currentbreath >= jumpDepletionRate;
    }
}
