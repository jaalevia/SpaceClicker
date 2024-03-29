using UnityEngine.Audio;
using UnityEngine;

[System.Serializable] 
public class Sound 
{
    public string name;
    [HideInInspector]
    public AudioSource sourse;
    public AudioClip clip;
    public bool loop;
    public AudioMixerGroup group;

    [Range(0f, 1f)]
    public float volume;
    [Range(.1f, 3f)]
    public float pitch;

}
