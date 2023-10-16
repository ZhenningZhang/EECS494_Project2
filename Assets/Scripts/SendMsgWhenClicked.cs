using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendMsgWhenClicked : MonoBehaviour
{
    // See ClickedEvents.cs for classes
    public void SendClickedMsg(int buttonNr)
    {
        EventBus.Publish<ClickedEvent>(new ClickedEvent(buttonNr));
    }
}
