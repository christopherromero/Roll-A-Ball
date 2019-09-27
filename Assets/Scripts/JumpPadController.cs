using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPadController : MonoBehaviour
{
    public int jumpForce;

    private void Start()
    {
        jumpForce = 200;
    }
    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.collider.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce);
        }
    }
}
