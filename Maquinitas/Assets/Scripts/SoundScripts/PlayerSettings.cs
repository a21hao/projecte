using UnityEngine.UI;
using UnityEngine;

public class PlayerSettings : MonoBehaviour
{

    [SerializeField] private Slider masterSlider;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider SFXSlider;
    // Start is called before the first frame update
    void Start()
    {
        masterSlider.value = PlayerPrefs.GetFloat("MasterVolume");
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        SFXSlider.value = PlayerPrefs.GetFloat("SFXVolume");
    }

    public void SetMasterPref()
    {
        PlayerPrefs.SetFloat("MasterVolume", masterSlider.value);
    }
    public void SetMusicPref()
    {
        PlayerPrefs.SetFloat("MusicVolume", musicSlider.value);
    }
    public void SetSFXPref()
    {
        PlayerPrefs.SetFloat("SFXVolume", SFXSlider.value);
    }

}
