using UnityEngine.UI;
using UnityEngine;

public class PlayerSettings : MonoBehaviour
{

    [SerializeField] private Slider masterSlider;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider SFXSlider;
	[SerializeField] private Slider ambienceSlider;
				// Start is called before the first frame update
				void Start()
    {
        masterSlider.value = PlayerPrefs.GetFloat("MasterVolume");
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        SFXSlider.value = PlayerPrefs.GetFloat("SFXVolume");
		ambienceSlider.value = PlayerPrefs.GetFloat("ambienceVolume");
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
				public void SetAmbiencePref()
				{
								PlayerPrefs.SetFloat("AmbiencewVolume", ambienceSlider.value);
				}

}
