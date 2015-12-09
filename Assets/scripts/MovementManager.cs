using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
public class MovementManager : MonoBehaviour
{
    public float MoveSpeed = 0.0f;
    public float JumpSpeed = 0.0f;

    private bool grounded = false;	//true when player is touching the ground
	private BreathManager bm;
	private ConfigManager cm;
	private Rigidbody rb;
	private float move;
	private float jump;
    // Use this for initialization
    void Start()
    {
		string fromconfig;
		//Get Components
		cm = GetComponent<ConfigManager> ();
        rb = GetComponent<Rigidbody>();
        bm = GetComponent<BreathManager>();
		//Initialize from configuration file
		fromconfig = cm.Load("MoveSpeed");
		MoveSpeed = (float)Int32.Parse(fromconfig);
		fromconfig = cm.Load("JumpSpeed");
		JumpSpeed = (float)Int32.Parse(fromconfig);
    }

    // Update is called once per frame
    void Update()
    {
		// Get user movement input: 1 for 'right', -1 for 'left', 0 for no input
        move = Input.GetAxisRaw("Horizontal") * MoveSpeed;	//Track movement
        jump =0f;	//Disable jump at the beginning of the frame
		// Jump in frame that space is pushed if possible
        if (Input.GetKeyDown("space") && grounded && bm.CanJump())
        {
            bm.BreathJump();	//decrease breath when jumping
            jump = JumpSpeed;	//enable jump movement
        }
 		//Set velocity vector for frame. Jumping is implemented as instantaneous
		//upward velocity, which is reduced by gravity due to Unity's Rigidbody component
        rb.velocity = new Vector3(move, rb.velocity.y + jump, 0.0f);
    }
	//There is a trigger collider at the Player object's feet which is used to detect
	//whether the player is on the ground.
	//Set grounded when player touches the terrain
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Floor"))	
            grounded = true;
    }
	//Set grounded to false when player leaves terrain
    void OnTriggerExit(Collider other)
    {
		if (other.CompareTag("Floor"))	
        	grounded = false;
    }
	//Test whether player is moving
    public bool IsMoving()
    {
        return rb.velocity.magnitude > 0.1f;
    }
	//Test whether player is running via input keys
    public bool IsRunning()
    {
        return Input.GetAxis("Horizontal") != 0.0f;
    }
}
