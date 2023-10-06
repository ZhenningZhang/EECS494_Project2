using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendMsgWhenActivated : MonoBehaviour
{
    [SerializeField]
    int cubeNr = -1;

    public void SendMessage(bool activate)
    {
        EventBus.Publish<ActivateEvent>(new ActivateEvent(cubeNr, activate));
    }
}

public class ActivateEvent
{
    public int cubeNr = -1;
    public bool activate = false;
    public ActivateEvent(int cubeNr, bool activate) 
    { 
        this.cubeNr = cubeNr;
        this.activate = activate;
    }
}
