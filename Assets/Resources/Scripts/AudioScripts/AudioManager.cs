using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;
    Sound currentSound;

    // Start is called before the first frame update
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
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
        return s.clip.length;
    }

    public float PlayFrom(string name, GameObject game)
    {
        //Sound s = Array.Find(sounds, sound => sound.name == name);
        currentSound = Array.Find(sounds, sound => sound.name == name);
        currentSound.source.GetComponent<Transform>().position = game.GetComponent<Transform>().position;
        currentSound.source.clip = currentSound.clip;
        currentSound.source.volume = currentSound.volume;
        currentSound.source.pitch = currentSound.pitch;

        currentSound.source.Play();
        //AudioSource.PlayClipAtPoint(s.clip, game.GetComponent<Transform>().position);
        return currentSound.clip.length;
    }

    public void Stop()
    {
        currentSound.source.Stop();
    }
}
