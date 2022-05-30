using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] string _volumeParameter = "MasterVol";
    [SerializeField] AudioMixer _mixer;
    [SerializeField] float _multiplier = 30f;
    [SerializeField] Slider volumeSlider;

    void Start()
    {
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
            Load();
        }
        else
        {
            Load();
        }
    }

    private void Awake()
    {
        volumeSlider.onValueChanged.AddListener(ValueChanged);
    }

    private void ValueChanged(float value)
    {
        if (value == 0)
            value = 0.000001f;
        _mixer.SetFloat(_volumeParameter, Mathf.Log10(value) * _multiplier);
    }

    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
        _mixer.SetFloat(_volumeParameter, Mathf.Log10(PlayerPrefs.GetFloat("musicVolume")));
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }
}