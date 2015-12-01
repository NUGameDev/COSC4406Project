using UnityEngine;
using System.Collections;

public class movementscript2d : MonoBehaviour
{

    Rigidbody rd;
    private const float moveSpeed = 10.0f;
    // Use this for initialization
    void Start()
    {
        rd = GetComponent<Rigidbody>();
    }

    // FixedUpdate is called once per physics frame
    void Update()
    {
        float s = Input.GetAxisRaw("Horizontal") * moveSpeed;
        //c.SimpleMove(Vector3.right * s);
        rd.AddRelativeForce(new Vector3(0.0f, 0.0f, 1.0f) * s);
        //Prevent the character from moving in the z direction
        //transform.position = new Vector3(transform.position.x, transform.position.y, 0.0f);
    }
}
