using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearWhenActivated : MonoBehaviour
{

    [SerializeField]
    int activationNr = -1;

    Subscription<ActivateEvent> activate_event_subscription;

    void Start()
    {
        gameObject.SetActive(false);
        activate_event_subscription = EventBus.Subscribe<ActivateEvent>(OnActivate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnActivate(ActivateEvent ae)
    {
        if (ae.cubeNr == activationNr)
            if (ae.activate == true)
                gameObject.SetActive(true);
            else
                gameObject.SetActive(false);
    }
}
