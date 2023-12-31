using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelClearedDisplayer : MonoBehaviour
{
    // Should use some smart way, but O(n) is no too bad in Menu
    [SerializeField]
    int levelNr = -1;

    Subscription<LevelClearedEventMenu> levelClearedEvent;
    Button button;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        levelClearedEvent = EventBus.Subscribe<LevelClearedEventMenu>(Cleared);
        button.interactable = false;
    }

    void Cleared(LevelClearedEventMenu levelClearedEvent)
    {
        if (levelClearedEvent.level == levelNr)
        {
            ColorBlock colors = button.colors;
            colors.normalColor = new Color32(0x3C, 0xB3, 0x71, 0xFF);
            button.colors = colors;
        }

        if (levelClearedEvent.level == levelNr - 1)
            button.interactable = true;
    }

    void OnDestroy()
    {
        EventBus.Unsubscribe(levelClearedEvent);
    }
}
