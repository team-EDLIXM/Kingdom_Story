using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;
using UnityEngine.Audio;

public class OptionsScript : MonoBehaviour
{
    public TMP_Dropdown wmode;
    public TMP_Dropdown resolution;
    private List<Resolution> ress = new List<Resolution>();
    private List<string> SoundPrefs = new List<string>() { "Master", "Music", "OtherSounds" };

    public AudioMixer mixer;

    void Start()
    {
        //Window Mode
        wmode.value = PlayerPrefs.HasKey("wmode") ?
            PlayerPrefs.GetInt("wmode") : 0;

        //Resolution
        int prevWidth = 0;
        int prevHeight = 0;
        ress = new List<Resolution>();
        foreach (var x in Screen.resolutions.Reverse())
            if ((x.width != prevWidth) && (x.height != prevHeight))
            {
                ress.Add(x);
                prevWidth = x.width;
                prevHeight = x.height;
            }

        resolution.ClearOptions();
        resolution.AddOptions(ress.Select(x => x.ToString()).ToList());
        resolution.value = PlayerPrefs.HasKey("resolution") ?
            PlayerPrefs.GetInt("resolution") : 0;

        //Audio
        foreach (var s in SoundPrefs)
        {
           mixer.SetFloat(s,PlayerPrefs.GetFloat(s, 0f));
        }
    }

    void Update()
    {
        
    }

    public void wmodechange()
    {
        switch (wmode.value)
        {
            case 0:
                Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
                break;
            case 1:
                Screen.fullScreenMode = FullScreenMode.MaximizedWindow;
                break;
            case 2:
                Screen.fullScreenMode = FullScreenMode.Windowed;
                break;
            default: break;
        }
        PlayerPrefs.SetInt("wmode", wmode.value);
    }
    public void reschange()
    {
      Screen.SetResolution(ress[resolution.value].width, ress[resolution.value].height, Screen.fullScreenMode);
            PlayerPrefs.SetInt("resolution", resolution.value);
    }
  
}
