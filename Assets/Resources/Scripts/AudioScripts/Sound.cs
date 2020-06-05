using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound 
{
    public string name;

    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;
    [Range(.1f,3f)]
    public float pitch;

    [HideInInspector]
    public AudioSource source;

    public Sound(AudioClip c, AudioSource mySource)
    {
        name = c.name;
        clip = c;
        volume = 0.5f;
        pitch = 1;
        source = mySource;
    }
}
