using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LighInput : MonoBehaviour
{
    GameObject torchLight;
    PlayerMovement playerMovement;

    void Start()
    {
        // This component is really guilty, I should have used PubSub for this
        torchLight = GetComponentInChildren<Light>().gameObject;
        playerMovement = GetComponentInParent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            torchLight.SetActive(true);
            playerMovement.varSpeed = 0.3f;
        }

        if (Input.GetMouseButtonUp(0))
        {
            torchLight.SetActive(false);
            playerMovement.varSpeed = 1.0f;
        }
    }
}
