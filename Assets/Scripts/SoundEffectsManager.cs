using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SoundEffectsManager : MonoBehaviour
{
    public static SoundEffectsManager Instance { get; private set; } // Don't know what this mean

    [SerializeField] AudioClip button_sound;
    [SerializeField] AudioClip esc_sound;
    [SerializeField] AudioClip on_sound;
    [SerializeField] AudioClip off_sound;

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
        EventBus.Subscribe<TouchEvent>(OnTouch);
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

    void OnTouch(TouchEvent activateEvent)
    {
        if (activateEvent.activate == true)
        {
            audioSource.PlayOneShot(on_sound);
        }
        if (activateEvent.activate == false)
        {
            audioSource.PlayOneShot(off_sound);
        }
    }
}
