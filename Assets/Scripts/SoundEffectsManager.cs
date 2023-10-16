using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectsManager : MonoBehaviour
{
    public static SoundEffectsManager Instance { get; private set; } // Don't know what this mean

    [SerializeField] AudioClip button_sound;
    [SerializeField] AudioClip esc_sound;
    AudioSource audioSource;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        EventBus.Subscribe<ClickedEvent>(OnButtonClicked);
        EventBus.Subscribe<EscEvent>(OnEsc);
        audioSource = GetComponent<AudioSource>();
    }

    void OnButtonClicked(ClickedEvent clickedEvent)
    {
        audioSource.PlayOneShot(button_sound);
    }

    void OnEsc(EscEvent escEvent)
    {
        audioSource.PlayOneShot(esc_sound);
    }
}
