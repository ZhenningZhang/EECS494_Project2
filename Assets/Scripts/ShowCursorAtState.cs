using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowCursorAtState : MonoBehaviour
{
    Subscription<TorchStateEvent> torch_state_event_subscription;
    Image image;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        image.enabled = false;
        torch_state_event_subscription = EventBus.Subscribe<TorchStateEvent>(OnStateChange);
    }

    // Update is called once per frame
    void OnStateChange(TorchStateEvent state)
    {
        if (state.torchState == 1)
        {
            image.enabled = true;
        }
        else
        {
            image.enabled = false;
        }
    }

    private void OnDestroy()
    {
        EventBus.Unsubscribe(torch_state_event_subscription);
    }
}
