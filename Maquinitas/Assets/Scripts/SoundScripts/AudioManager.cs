using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class AudioManager : MonoBehaviour
{

    [Range(0, 1)]

    public float masterVolume = 1;

    [Range(0, 1)]
    public float musicVolume = 1;

    [Range(0, 1)]
    public float SFXVolume = 1;

	[Range(0, 1)]
	public float ambienceVolume = 1;

    private static bool musicPlaying = false;

	private Bus masterBus;

    private Bus musicBus;

    private Bus sfxBus;

	private Bus ambienceBus;

	private EventInstance ambienceEventInstance;

	public static AudioManager instance { get; private set; }

    private EventInstance musicEventInstance;

    
    private void Awake()
    {

        if (instance != null)
        {
            Debug.LogError("More than 1  audio manager in scene");
        }
        else
        {
            instance = this;

        }

        masterBus = RuntimeManager.GetBus("bus:/");

        musicBus = RuntimeManager.GetBus("bus:/Music");

        sfxBus = RuntimeManager.GetBus("bus:/SFX");

		ambienceBus = RuntimeManager.GetBus("bus:/Ambience");
	}

    private void Start()
    {
        Debug.Log(musicPlaying);

        if (!musicPlaying)
        {
            InitializeMusic(FMODEvents.instance.music);

            InitializeAmbience(FMODEvents.instance.ambience);

            musicPlaying = true;
        }
        Debug.Log(musicPlaying);
    }

    private void Update()
    {
        masterBus.setVolume(masterVolume);
        musicBus.setVolume(musicVolume);
        sfxBus.setVolume(SFXVolume);
		ambienceBus.setVolume(ambienceVolume);
	}

    public void PlayOneShot(EventReference sound, Vector3 worldPos)
    {
        RuntimeManager.PlayOneShot(sound, worldPos);
    }

    public EventInstance CreateInstance(EventReference eventReference)
    {
        EventInstance eventInstance = RuntimeManager.CreateInstance(eventReference);
        return eventInstance;
    }

    private void InitializeMusic(EventReference musicEventReference)
    {
        musicEventInstance = CreateInstance(musicEventReference);
        musicEventInstance.start();
    }

	private void InitializeAmbience(EventReference ambienceEventReference)
	{

		ambienceEventInstance = CreateInstance(ambienceEventReference);
        ambienceEventInstance.start();
	}
}

