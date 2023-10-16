using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearWhenActivated : MonoBehaviour
{

    [SerializeField]
    int activationNr = -1;

    void Start()
    {
        gameObject.SetActive(false);
        EventBus.Subscribe<TouchEvent>(OnActivate);
    }

    void OnActivate(TouchEvent ae)
    {
        if (ae.cubeNr == activationNr)
            if (ae.activate == true)
                gameObject.SetActive(true);
            else
                gameObject.SetActive(false);
    }
}
