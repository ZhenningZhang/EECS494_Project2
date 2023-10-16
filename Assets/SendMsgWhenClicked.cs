using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendMsgWhenClicked : MonoBehaviour
{
    public void SendClickedMsg(int buttonNr)
    {
        EventBus.Publish<ClickedEvent>(new ClickedEvent(buttonNr));
    }
}

public class ClickedEvent
{
    public int button;
    public ClickedEvent(int button)
    {
        this.button = button;
    }
}
