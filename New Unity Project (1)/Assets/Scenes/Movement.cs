using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public AudioClip _sound;    // this lets you drag in an audio file in the inspector
    private AudioSource audio;
    // Start is called before the first frame update
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

    // Update is called once per frame
    void Update()
    {
        // To move the character in negative x axis i.e left
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Vector3 position = this.transform.position;
            position.x = position.x - 1;
            this.transform.position = position;
        }
       // to move the character in positive x axis i.e right
        if (Input.GetKeyDown(KeyCode.RightArrow)) 
        {
            Vector3 position = this.transform.position;
            position.x = position.x + 1;
            this.transform.position = position;
        }
       // to move in positive z direction i.e forward
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            Vector3 position = this.transform.position;
            position.z = position.z + 1;
            this.transform.position = position;
        }
        //To move in negative z direction i.e backward
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            Vector3 position = this.transform.position;
            position.z = position.z - 1;
            this.transform.position = position;
        }
    }
}
