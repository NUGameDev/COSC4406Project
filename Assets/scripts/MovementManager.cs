using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
public class MovementManager : MonoBehaviour
{
   // public Slider breathslider;
  //  private float currentbreath;
    Rigidbody rb;

    public float MoveSpeed = 0.0f;
    public float JumpSpeed = 0.0f;
    bool grounded = false;
    BreathManager bm;
	ConfigManager cm;
    // Use this for initialization
    void Start()
    {
		string fromconfig;
		cm = GetComponent<ConfigManager> ();
        rb = GetComponent<Rigidbody>();
      //  currentbreath = breathslider.value;
        bm = GetComponent<BreathManager>();
		fromconfig = cm.Load("MoveSpeed");
		MoveSpeed = (float)Int32.Parse(fromconfig);
		fromconfig = cm.Load("JumpSpeed");
		JumpSpeed = (float)Int32.Parse(fromconfig);

    }

    // FixedUpdate is called once per physics frame
    void Update()
    {
        float move = Input.GetAxisRaw("Horizontal") * MoveSpeed;
        float jump =0f;
       // if (currentbreath > 0.0f)
       // {
        //     jump = Input.GetAxisRaw("Jump") * JumpSpeed;
        // }
        if (Input.GetKeyDown("space") && grounded && bm.CanJump())
        {
            bm.BreathJump();
            jump = JumpSpeed;
        }
      
        //c.SimpleMove(Vector3.right * s);
        rb.velocity = new Vector3(move, rb.velocity.y + jump, 0.0f);
        jump = 0f;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Floor"))
            grounded = true;

    }

    void OnTriggerExit(Collider other)
    {
		if (other.CompareTag("Floor"))
        	grounded = false;
    }
    public bool IsMoving()
    {
        return rb.velocity.magnitude > 0.1f;
    }
    public bool IsRunning()
    {
        return Input.GetAxis("Horizontal") != 0.0f;
    }
}
