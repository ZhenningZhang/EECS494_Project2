using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendMsgWhenTouch : MonoBehaviour
{

    [SerializeField]
    int cubeNr = -1;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EventBus.Publish<ActivateEvent>(new ActivateEvent(cubeNr, true));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EventBus.Publish<ActivateEvent>(new ActivateEvent(cubeNr, false));
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            EventBus.Publish<ActivateEvent>(new ActivateEvent(cubeNr, true));
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            EventBus.Publish<ActivateEvent>(new ActivateEvent(cubeNr, false));
        }
    }
}
