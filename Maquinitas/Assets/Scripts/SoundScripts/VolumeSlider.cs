using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    private enum VolumeType
    {
        MASTER,

        MUSIC,

        SFX
    }

    [SerializeField] private VolumeType volumeType;

    private Slider volumeSlider;

    private void Awake()
    {
        volumeSlider = this.GetComponentInChildren<Slider>();
    }

    private void Start()
    {
        //volumeSlider.value = PlayerPrefs.GetFloat("MasterVolume");
        //volumeSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        //volumeSlider.value = PlayerPrefs.GetFloat("SFXVolume");

        //AudioManager.instance.masterVolume = PlayerPrefs.GetFloat("MasterVolume");
        //AudioManager.instance.musicVolume = PlayerPrefs.GetFloat("MusicVolume");
        //AudioManager.instance.SFXVolume = PlayerPrefs.GetFloat("SFXVolume");

    }

    private void Update()
    {
        switch (volumeType)
        {
            case VolumeType.MASTER:
                volumeSlider.value = AudioManager.instance.masterVolume;
                break;
            case VolumeType.MUSIC:
                volumeSlider.value = AudioManager.instance.musicVolume;
                break;
            case VolumeType.SFX:
                volumeSlider.value = AudioManager.instance.SFXVolume;
                break;
            default:
                Debug.LogWarning("???????como???????");
            break;
        }
    }

    public void OnSliderValueChange()
    {
        switch (volumeType)
        {
            case VolumeType.MASTER:
                AudioManager.instance.masterVolume = volumeSlider.value;
                break;
            case VolumeType.MUSIC:
                AudioManager.instance.musicVolume = volumeSlider.value;
                break;
            case VolumeType.SFX:
                AudioManager.instance.SFXVolume = volumeSlider.value;
                break;
            default:
                Debug.LogWarning("???????como???????");
                break;
        }
    }
}
