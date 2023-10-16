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
            EventBus.Publish<TouchEvent>(new TouchEvent(cubeNr, true));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EventBus.Publish<TouchEvent>(new TouchEvent(cubeNr, false));
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            EventBus.Publish<TouchEvent>(new TouchEvent(cubeNr, true));
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            EventBus.Publish<TouchEvent>(new TouchEvent(cubeNr, false));
        }
    }
}

public class TouchEvent
{
    public int cubeNr = -1;
    public bool activate = false;
    public TouchEvent(int cubeNr, bool activate)
    {
        this.cubeNr = cubeNr;
        this.activate = activate;
    }
}
