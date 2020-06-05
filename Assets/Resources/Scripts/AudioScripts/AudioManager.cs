using UnityEngine.Audio;
using System;
using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    [HideInInspector]
    public List<Sound> sounds;
    Sound currentSound;
    AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();

        AudioClip[] clips;
        clips = Resources.LoadAll<AudioClip>("Audio");
        foreach (AudioClip c in clips)
        {
            Sound s = new Sound(c, source);
            sounds.Add(s);
        }
    }

    // Load the sound
    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.GetComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }


    void PlaySound()
    {
        
    }
    
    public float Play(string name)
    {
        
        Sound s = sounds.Find(sound => sound.name == name);
        s.source.Play();
        return s.clip.length;
    }

    public float PlayFrom(string name, GameObject game)
    {
        currentSound = sounds.Find(sound => sound.name == name);

        currentSound.source.GetComponent<Transform>().position = game.GetComponent<Transform>().position;
        currentSound.source.clip = currentSound.clip;
        currentSound.source.volume = currentSound.volume;
        currentSound.source.pitch = currentSound.pitch;

        currentSound.source.Play();
        return currentSound.clip.length;
    }

    public void Stop()
    {
        currentSound.source.Stop();
    }
}
