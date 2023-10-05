using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 10;

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime;
        transform.Translate(horizontal, 0, 0);

        float vertical = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;
        transform.Translate(0, 0, vertical);
    }
}
