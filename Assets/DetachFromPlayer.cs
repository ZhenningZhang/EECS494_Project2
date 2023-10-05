using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetachFromPlayer : MonoBehaviour
{
    Subscription<TorchStateEvent> torch_state_event_subscription;

    void Start()
    {
        torch_state_event_subscription = EventBus.Subscribe<TorchStateEvent>(OnStateChange);
    }

    void OnStateChange(TorchStateEvent state)
    {
        if (state.torchState == 1)
        {
            transform.SetParent(null);
        }
    }

    private void OnDestroy()
    {
        EventBus.Unsubscribe(torch_state_event_subscription);
    }
}
