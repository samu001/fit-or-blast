using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public Sound[] sounds;  //An array of the class Sound

    void Awake() {

        foreach (Sound s in sounds) {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
        //loop through the list and for each sound slot add an audio source
    }


    public void Play(string name) {

        //Find the sound in the sounds array
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null) {

            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Play();

    }

    public void playLoseUIsound() {
        Play("lose level");
    }



}
