using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TorchStateDisplayer : MonoBehaviour
{

    Subscription<TorchStateEvent> torch_state_event_subscription;
    TextMeshProUGUI text;

    void Start()
    {
        torch_state_event_subscription = EventBus.Subscribe<TorchStateEvent>(OnStateChange);
        text = GetComponent<TextMeshProUGUI>();

        text.text = "Handheld Mode";
        StartCoroutine(WaitAndFade(0.0f, 0.0f));
    }

    void OnStateChange(TorchStateEvent state)
    {
        if (state.torchState == 0)
        {
            text.text = "Handheld Mode";
        }
        if (state.torchState == 1)
        {
            text.text = "LightHouse Mode";
        }
        if (state.torchState == 2)
        {
            text.text = "Drone Mode";
        }
        StartCoroutine(WaitAndFade(1.0f, 0.5f));
    }

    IEnumerator WaitAndFade(float waitSecond, float fadeSecond)
    {
        Color color = text.color;
        color.a = 1.0f;
        text.color = color;
        yield return null;

        yield return new WaitForSeconds(waitSecond);

        float init_time = Time.time;
        float progress = 0.0f;

        while (progress < 1.0f)
        {
            progress = (Time.time - init_time) / fadeSecond;
            color.a = Mathf.Lerp(1.0f, 0.0f, progress);
            text.color = color;
            yield return null;
        }

        color.a = 0.0f;
        text.color = color;
        yield return null;
    }

    private void OnDestroy()
    {
        EventBus.Unsubscribe(torch_state_event_subscription);
    }
}
