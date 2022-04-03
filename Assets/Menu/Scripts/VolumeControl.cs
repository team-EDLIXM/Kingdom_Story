using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class VolumeControl : MonoBehaviour
{
    public string MixerGroup = "Master";
    public AudioMixer mixer;
    public Slider slider;

    private float _volumeValue;
    private const float _multiplier = 20f;

    private void Awake()
    {
        slider.onValueChanged.AddListener(HandleSliderValueChanged);
    }

    private void HandleSliderValueChanged(float value)
    {
        _volumeValue = value == 0 ?
            -80f : Mathf.Log10(value) * _multiplier;
        mixer.SetFloat(MixerGroup, _volumeValue);
    }
    void Start()
    {
        _volumeValue = PlayerPrefs.GetFloat(MixerGroup, 0f);
        slider.value = _volumeValue == 0 ?
            1 : Mathf.Pow(10f, _volumeValue / _multiplier);
    }

    private void OnDisable()
    {
        PlayerPrefs.SetFloat(MixerGroup, _volumeValue);
    }
}
