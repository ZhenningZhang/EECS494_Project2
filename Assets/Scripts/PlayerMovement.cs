using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 10;
    public float jumpForce = 200;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime;
        transform.Translate(horizontal, 0, 0);

        float vertical = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;
        transform.Translate(0, 0, vertical);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce);
        }
    }
}
