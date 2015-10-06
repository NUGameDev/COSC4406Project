using UnityEngine;
using System.Collections;

public class movementscript2d : MonoBehaviour
{

    CharacterController c;
    private const float moveSpeed = 20.0f;
    // Use this for initialization
    void Start()
    {
        c = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float s = Input.GetAxisRaw("Horizontal") * moveSpeed;
        c.SimpleMove(Vector3.right * s);
    }
}
