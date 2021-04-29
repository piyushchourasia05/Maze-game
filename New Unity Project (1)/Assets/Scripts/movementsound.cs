using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementsound : MonoBehaviour
{
    public AudioClip _sound;    // this lets you drag in an audio file in the inspector
    private AudioSource audio;

    void Start()
    {
        if (_sound == null)
        {
            Debug.Log("You haven't specified _sound through the inspector");
            this.enabled = false; //disables this script cause there is no sound loaded to play
        }

        audio = gameObject.AddComponent<AudioSource>(); //adds an AudioSource to the game object this script is attached to
        audio.playOnAwake = false;
        audio.clip = _sound;
        audio.Stop();
    }

    void Update()
    {
        if (Input.GetButtonDown("w"))
        {
            audio.Play();
        }
        if (Input.GetButtonDown("a"))
        {
            audio.Play();
        }
        if (Input.GetButtonDown("s"))
        {
            audio.Play();
        }
        if (Input.GetButtonDown("d"))
        {
            audio.Play();
        }
    }
}