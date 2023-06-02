using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSlider : MonoBehaviour
{
    [SerializeField] private AudioClip _onValueChangedSound;
    
    private const int MIN_DECIBELS = -80;
    private const int MAX_DECIBELS = 20;
    private const int DECIBEL_LOG_BASE = 10;
    
    private TextMeshProUGUI _label;
    private AudioMixerGroup _audioMixerGroup;
    private Slider _slider;
    private AudioSource _audioSource;

    private string VolumeParameterName => $"{_audioMixerGroup.name}Volume";

    public AudioMixerGroup AudioMixerGroup
    {
        get => _audioMixerGroup;
        set
        {
            _audioMixerGroup = value;
            UpdateSliderValue();
        }
    }
    
    public string Text
    {
        get => _label.text;
        set => _label.text = value;
    }

    private void Awake()
    {
        _label = GetComponentInChildren<TextMeshProUGUI>();
        _slider = GetComponent<Slider>();
        _audioSource = GetComponent<AudioSource>();
        _slider.onValueChanged.AddListener(SetValue);
    }

    private void UpdateSliderValue()
    {
        _audioMixerGroup.audioMixer.GetFloat(VolumeParameterName, out var value);
        _slider.value = Mathf.InverseLerp(MIN_DECIBELS, MAX_DECIBELS, CalculateLinearVolume(value));
    }

    private void SetValue(float value)
    {
        _audioMixerGroup.audioMixer.SetFloat(VolumeParameterName, CalculateVolumeInDecibels(value));
    }

    public void Select()
    {
        _slider.Select();
    }

    private static float CalculateLinearVolume(float volumeInDecibels)
    {
        return Mathf.Pow(volumeInDecibels / MAX_DECIBELS, DECIBEL_LOG_BASE);
    }

    private static float CalculateVolumeInDecibels(float linearVolume)
    {
        if (linearVolume == 0)
        {
            return MIN_DECIBELS;
        }
        return MAX_DECIBELS * Mathf.Log(linearVolume, DECIBEL_LOG_BASE);
    }

    public void ActivateOnValueChangedSound()
    {
        _slider.onValueChanged.AddListener(_ => _audioSource.PlayOneShot(_onValueChangedSound));
    }
}
