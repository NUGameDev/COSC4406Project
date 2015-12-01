using UnityEngine;
using System.Collections;

public class movementscript2d : MonoBehaviour
{

    Rigidbody rb;
    public float MoveSpeed = 10.0f;
    public float JumpSpeed = 20.0f;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // FixedUpdate is called once per physics frame
    void FixedUpdate()
    {
        float move = Input.GetAxisRaw("Horizontal") * MoveSpeed;
        float jump = Input.GetAxisRaw("Jump") * JumpSpeed;

        //c.SimpleMove(Vector3.right * s);
        rb.velocity = new Vector3(move, rb.velocity.y + jump, 0.0f); 
    }
}
