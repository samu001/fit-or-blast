using UnityEngine.Audio;
using UnityEngine;



[System.Serializable]  //Needed for custom class to appear on the inspector
public class Sound {
    public string name;

    //reference for AudioClip Object
    public AudioClip clip;

    //To put an slider on the Inspector
    [Range(0f, 2f)]
    public float volume;
    [Range(.1f, 3f)]
    public float pitch;

    [HideInInspector]  //even tho variable is public it won't show
    public AudioSource source;
}
