using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveTorch : MonoBehaviour
{
    static int state = 0;

    void Update()
    {
        state++;
        state %= 3;

        if (Input.GetKeyDown(KeyCode.Q))
        {
            EventBus.Publish<TorchStateEvent>(new TorchStateEvent(state));
        }
    }
}

public class TorchStateEvent
{
    public int torchState = 0;
    public TorchStateEvent(int state) { torchState = state; }
}
