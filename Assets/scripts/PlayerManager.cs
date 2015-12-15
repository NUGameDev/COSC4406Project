using UnityEngine;
using System.Collections;
using System;
using System.Diagnostics;

/// <summary>
/// Manages actions of the player and also handles player resources including
/// breath and puffer charge. 
/// </summary>
public class PlayerManager: MonoBehaviour {
    private const float ROTATION_ANGLE_RIGHT = 90.0f;
    private const float ROTATION_ANGLE_LEFT = 270.0f; 

    public float MoveSpeed = 8.0f;
    public float JumpSpeed = 10.0f;

    public float JumpDepletionAmount = 5.0f;
    public float RunDepletionRate = 1.5f;
    public int   BreathRecoveryTimeout = 2000;
    public float BreathRecoveryRate = 3.5f;
    public float PufferBreathRecovered = 25f;

    public float MaxBreath = 100f;
    public float MaxPufferCharge = 100f;

    public float PufferCostSelf = 20f;
    public float PufferCostSpray = 10f;

    private float currentBreath;
    private float currentPufferCharge;

    public Transform PufferCloud = null;

    private Rigidbody rb;
    private int direction = 1; //1 means looking left, -1 means looking right. 
    private bool grounded = false;

    private Stopwatch recoveryTimer = new Stopwatch();

	// Use this for initialization
	void Start () {
        currentBreath = MaxBreath;
        currentPufferCharge = MaxPufferCharge;

        rb = GetComponent<Rigidbody>();
	}

    /// <summary>
    /// Manually delete the specified amount of breath from the player.
   ///  Does not allow the breath to become negative. 
    /// </summary>
    /// <param name="amt"> amount to reduce breath by. </param>
    public void DepleteBreath(float amt)
    {
        currentBreath = Mathf.Max(0f, currentBreath - amt);
    }

    public float getBreath()
    {
        return this.currentBreath;
    }

    public float getPufferCharge()
    {
        return this.currentPufferCharge;
    }
    /// <summary>
    /// Determine whether the player is running. 
    /// </summary>
    /// <returns>True if the player is currently running. False otherwise. </returns>
    public bool isRunning()
    {
        if (rb == null) return false;
        return Mathf.Abs(rb.velocity.x) > 0.1;
    }

    /// <summary>
    /// Use puffer on self. Fails if puffer charge is too low.  
    /// </summary>
    public void PufferUseSelf()
    {
        if (this.currentPufferCharge < PufferCostSelf) return;
        currentPufferCharge -= PufferCostSelf;
        currentBreath = Mathf.Min(MaxBreath, currentBreath + PufferBreathRecovered);
        //TODO: play animation here. 
    }

    /// <summary>
    /// Spray a cloud of puffer spray in front of the player. 
    /// Does nothing if charge is too low. 
    /// </summary>
    public void PufferSpray()
    {
        if (this.currentPufferCharge < PufferCostSpray) return;
        currentPufferCharge -= PufferCostSpray;
        //create puffer ball object
        float xoffset = this.direction * 1.5f;

        Instantiate(PufferCloud,
            new Vector3(transform.position.x + xoffset, transform.position.y + 1.5f, transform.position.z),
            Quaternion.identity);
    }
	
    /// <summary>
    /// Run in a direction.
    /// </summary>
    /// <param name="direction">Direction to run. Positive values are to the left. </param>
    public void run(float direction)
    {
        direction = Mathf.Clamp(direction, -1.0f, 1.0f);
        Transform tmesh = transform.Find("Armature").transform;
        //rotate model so he is facing in direction of movement. 
        if (direction < 0.0f)
        {
            this.direction = -1;
            tmesh.eulerAngles = new Vector3(tmesh.eulerAngles.x, ROTATION_ANGLE_LEFT, tmesh.eulerAngles.z);
        }
        else if (direction > 0.0f)
        {
            this.direction = 1;
            tmesh.eulerAngles = new Vector3(tmesh.eulerAngles.x, ROTATION_ANGLE_RIGHT, tmesh.eulerAngles.z);
        }

        //now apply the velocity to the rigidbody.
        rb.velocity = new Vector3(direction * MoveSpeed, rb.velocity.y, rb.velocity.z);
    }

    /// <summary>
    /// Command the player to jump. Player must have sufficient breath to jump. 
    /// We must also determine if the player is touching the ground and is therefore able to jump. 
    /// </summary>
    public void jump()
    {
        if (currentBreath < JumpDepletionAmount) return;
        if (!grounded) return;
        currentBreath -= JumpDepletionAmount;
        rb.velocity += new Vector3(0.0f, JumpSpeed, 0.0f);
    }

    void Update()
    {
        //Start/reset the recovery timer based on if we're running or not. Also deplete breath
        if (this.isRunning())
        {
            recoveryTimer.Reset();
            this.DepleteBreath(RunDepletionRate * Time.smoothDeltaTime);

        }
        else recoveryTimer.Start();

        //if we've passed the recovery time then we can start recovering breath
        if(recoveryTimer.ElapsedMilliseconds > BreathRecoveryTimeout)
        {
            currentBreath = Math.Min(MaxBreath, currentBreath + BreathRecoveryRate * Time.smoothDeltaTime);
        }
    }

    /// <summary>
    /// Used for keeping track of if the player is touching the ground or not. 
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Floor"))
            grounded = true;

    }

    /// <summary>
    /// Used to track if the player is touching the ground for jumping purposes.
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Floor"))
            grounded = false;
    }

    public void addPufferCharge(float amount)
    {
        amount = Math.Max(amount, 0.0f);
        this.currentPufferCharge = Math.Min(MaxPufferCharge, amount + currentPufferCharge);
    }
}
