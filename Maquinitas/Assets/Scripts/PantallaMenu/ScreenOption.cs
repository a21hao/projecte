using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScreenOption : MonoBehaviour
{
    [SerializeField] Toggle fullscreenToggle;
    [SerializeField] Toggle borderlessToggle;
    [SerializeField] TMP_Dropdown screenDropdown;
    Resolution[] resolutions;

    void Start()
    {
        fullscreenToggle.isOn = Screen.fullScreen;
        borderlessToggle.isOn = Screen.fullScreenMode == FullScreenMode.FullScreenWindow;
        ScreenResolution();
    }

    void Update()
    {
        
    }

    public void ToggleFullScreen()
    {
        Screen.fullScreen = fullscreenToggle.isOn;
    }

    public void ToggleBorderless()
    {
        if (borderlessToggle.isOn)
        {
            Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
        }
        else
        {
            Screen.fullScreenMode = FullScreenMode.Windowed;
        }
    }

    public void ScreenResolution()
    {
        resolutions = Screen.resolutions;
        screenDropdown.ClearOptions();
        List<string> opciones = new List<string>();
        int actualResolution = 0;

        for (int i = 0; i < resolutions.Length; i++){
            string opcion = resolutions[i].width + " x " + resolutions[i].height + " - " + Mathf.RoundToInt(resolutions[i].refreshRate) + "hz";
            opciones.Add(opcion);

            if(Screen.fullScreen && resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                actualResolution = i;
            }
        }

        screenDropdown.AddOptions(opciones);
        screenDropdown.value = actualResolution;
        screenDropdown.RefreshShownValue();

        screenDropdown.value = PlayerPrefs.GetInt("resolution", 0);
    }

    public void ChangeResolution(int resolutionInt)
    {
        PlayerPrefs.SetInt("resolution", screenDropdown.value);

        Resolution resolution = resolutions[resolutionInt];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
