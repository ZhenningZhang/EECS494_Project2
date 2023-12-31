using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// Actually can just use AppearWhenActivated

public class AppearWhenCleared : MonoBehaviour
{
    Subscription<LevelClearedEvent> levelClearedEvent;
    TextMeshProUGUI text;

    void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
        text.enabled = false;
    }

    void Start()
    {
        levelClearedEvent = EventBus.Subscribe<LevelClearedEvent>(Cleared);
    }

    void Cleared(LevelClearedEvent levelClearedEvent)
    {
        // Which value returned is really not important
        // Since one level have only one Cleared Text
        text.text = "Level " + levelClearedEvent.level + " Cleared";
        text.enabled = true;
    }

    void OnDestroy()
    {
        EventBus.Unsubscribe(levelClearedEvent);
    }
}
