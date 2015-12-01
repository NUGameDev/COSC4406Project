using UnityEngine;
using System.Collections;

public class movementscript : MonoBehaviour {

    CharacterController c;
    private const float moveSpeed = 10.0f;
    private const float rotatespeed = 50.0f;
	// Use this for initialization
	void Start () {
        c = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        float s = Input.GetAxisRaw("Vertical") * moveSpeed;
        float r = Input.GetAxisRaw("Horizontal") * rotatespeed * Time.deltaTime;
        transform.Rotate(0, r, 0);
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        c.SimpleMove(forward * s);
	}
}
