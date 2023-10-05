using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveTorch : MonoBehaviour
{
    int state = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            state++;
            state %= 2;
            EventBus.Publish<TorchStateEvent>(new TorchStateEvent(state));
        }
    }
}

public class TorchStateEvent
{
    public int torchState = 0;
    public TorchStateEvent(int state) { torchState = state; }
}
