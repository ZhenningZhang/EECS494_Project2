using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetachFromPlayer : MonoBehaviour
{
    Subscription<TorchStateEvent> torch_state_event_subscription;
    Vector3 defaultPosition = Vector3.zero;
    Vector3 defaultScale = Vector3.one;
    Vector3 relativePosition = Vector3.zero;
    GameObject player;

    bool moveWithPlayer = false;

    void Start()
    {
        torch_state_event_subscription = EventBus.Subscribe<TorchStateEvent>(OnStateChange);

        defaultPosition = transform.localPosition;
        defaultScale = transform.localScale;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (moveWithPlayer)
        {
            transform.position = Vector3.Lerp(transform.position, player.transform.position + relativePosition,Time.deltaTime * 5.0f);
            //transform.rotation = Quaternion.Slerp(transform.rotation, player.transform.rotation, Time.deltaTime * 5.0f);
            transform.rotation = Quaternion.Slerp(transform.rotation, Camera.main.transform.rotation, Time.deltaTime * 5.0f);
        }
    }

    void OnStateChange(TorchStateEvent state)
    {
        if (state.torchState == 1){
            transform.SetParent(null);
        }

        if (state.torchState == 2)
        {
            relativePosition = transform.position - player.transform.position;
            moveWithPlayer = true;
        }

        if (state.torchState == 0)
        {
            moveWithPlayer = false;
            SetBack();
        }
    }

    private void SetBack()
    {
        transform.SetParent(player.transform);
        transform.localPosition = defaultPosition;
        transform.localScale = defaultScale;
    }

    private void OnDestroy()
    {
        EventBus.Unsubscribe(torch_state_event_subscription);
    }
}
