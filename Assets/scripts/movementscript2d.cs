using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class movementscript2d : MonoBehaviour
{
   // public Slider breathslider;
  //  private float currentbreath;
    Rigidbody rb;
    public float MoveSpeed = 10.0f;
    public float JumpSpeed = 20.0f;

    BreathManager bm;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
      //  currentbreath = breathslider.value;
        bm = GetComponent<BreathManager>();
    }

    // FixedUpdate is called once per physics frame
    void FixedUpdate()
    {
        float move = Input.GetAxisRaw("Horizontal") * MoveSpeed;
        float jump =0f;
       // if (currentbreath > 0.0f)
       // {
             jump = Input.GetAxisRaw("Jump") * JumpSpeed;
        // }

        if (jump != 0 && bm.CanJump())
        {
            bm.BreathJump();
        }
        else jump = 0f;
        //c.SimpleMove(Vector3.right * s);
        rb.velocity = new Vector3(move, rb.velocity.y + jump, 0.0f); 
    }
}
