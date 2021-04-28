using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 20f;
    public AudioClip _sound;    // this lets you drag in an audio file in the inspector
    private AudioSource audio;
    Vector3 velocity;
    public float gravity = -9.8f * 2;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public float jumpHeight = 3f;
    bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
       

        audio = gameObject.AddComponent<AudioSource>(); //adds an AudioSource to the game object this script is attached to
      
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        audio.Play();
        audio.loop = true;
        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime * Time.deltaTime;

        controller.Move(velocity);
    }
}
