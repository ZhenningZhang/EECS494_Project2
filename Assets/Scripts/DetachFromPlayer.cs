using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetachFromPlayer : MonoBehaviour
{
    Subscription<TorchStateEvent> torch_state_event_subscription;
    Vector3 defaultPosition = Vector3.zero;

    void Start()
    {
        torch_state_event_subscription = EventBus.Subscribe<TorchStateEvent>(OnStateChange);
        defaultPosition = transform.localPosition;
    }

    void OnStateChange(TorchStateEvent state)
    {
        if (state.torchState == 1){
            transform.SetParent(null);
        }

        if (state.torchState == 0)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            transform.SetParent(player.transform);
            transform.localPosition = defaultPosition;
        }
    }

    private void OnDestroy()
    {
        EventBus.Unsubscribe(torch_state_event_subscription);
    }
}
