using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;

public class Settings : MonoBehaviour
{
    public AudioMixer mixer;
    [SerializeField] TextMeshProUGUI masterVolumeSliderText;

    public void MasterVolume(float volume)
    {

        mixer.SetFloat("MasterVolume", volume);

        masterVolumeSliderText.text = ((int)(volume * 100)).ToString();
    }

}
