﻿using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    private void Start()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (!Utils.IsNullForSound(s))
        {
            return;
        }
        s.source.Play();
    }

    public void Stop(string name)
    {

        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (!Utils.IsNullForSound(s))
        {
            return;
        }
        s.source.Stop();
    }

    public void Pause(string name)
    {

        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (!Utils.IsNullForSound(s))
        {
            return;
        }
        s.source.Pause();
    }

    public float Time(string name)
    {

        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (!Utils.IsNullForSound(s))
        {
            return 0;
        }
        return s.source.time;
    }

    public bool IsPlaying(string name)
    {

        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (!Utils.IsNullForSound(s))
        {
            return false;
        }
        return s.source.isPlaying;
    }
}