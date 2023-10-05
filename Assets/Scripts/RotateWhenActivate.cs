using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWhenActivate : MonoBehaviour
{
    [SerializeField]
    int activationNr = -1;
    Subscription<ActivateEvent> activate_event_subscription;

    void Start()
    {
        activate_event_subscription = EventBus.Subscribe<ActivateEvent>(OnActivate);
    }

    void OnActivate(ActivateEvent ae)
    {
        if (ae.cubeNr == activationNr)
            transform.Rotate(new Vector3(0, 0, 80 * Time.deltaTime));
    }

    private void OnDestroy()
    {
        EventBus.Unsubscribe(activate_event_subscription);
    }
}
