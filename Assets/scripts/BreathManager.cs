using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Diagnostics;
using System;

public class BreathManager : MonoBehaviour {
    public Slider breathslider;
    private float currentbreath;
    public float jumpDepletionRate = 5.0f;
    public float runDepletionRate = 1.0f;
    public long recoveryWait = 2000;
    public float recoveryRate = 1f;

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
    public bool CanJump()
    {
        return currentbreath >= jumpDepletionRate;
    }
}
