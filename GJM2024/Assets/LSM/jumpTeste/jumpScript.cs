using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpScript : MonoBehaviour
{
    public Rigidbody rigidbody;
    public float jump; // 300 para 2x
    public float speed;
    public bool isGrounded = true;
    private void FixedUpdate()
    {
        rigidbody.AddForce(new Vector3(Input.GetAxis("Horizontal") * speed, -10, Input.GetAxis("Vertical") * speed));

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Debug.Log("-");
            rigidbody.AddForce(new Vector3(0, jump, 0), ForceMode.Impulse);
            isGrounded = false;
        }
        
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.name == "GroundTrigger")
        {
            isGrounded = true;
        }
    }
}
