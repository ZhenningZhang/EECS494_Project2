using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendMsgWhenActivated : MonoBehaviour
{
    [SerializeField]
    int cubeNr = -1;

    public void SendMessage()
    {
        EventBus.Publish<ActivateEvent>(new ActivateEvent(cubeNr));
    }
}

public class ActivateEvent
{
    public int cubeNr = -1;
    public ActivateEvent(int cubeNr) { this.cubeNr = cubeNr; }
}
