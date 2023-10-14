using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LeaveTorch : MonoBehaviour
{
    int state = 0;

    [SerializeField]
    int[] disabledModes;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            do
            {
                state++;
                state %= 3;
            }
            while (disabledModes != null && disabledModes.Contains(state));

            EventBus.Publish<TorchStateEvent>(new TorchStateEvent(state));
        }
    }
}

public class TorchStateEvent
{
    public int torchState = 0;
    public TorchStateEvent(int state) { torchState = state; }
}
