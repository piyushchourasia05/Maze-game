using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public CharacterController controller;


    public float speed = 20f;
    Vector3 velocity;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public float jumpHeight = 3f;
    bool isGrounded;

    public AudioClip sounds;    // this lets you drag in an audio file in the inspector
    public AudioSource audioSource;
    public float footStepTimer;


    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        
        
        controller.Move(move * speed * Time.deltaTime);

        controller.Move(velocity);
        if(velocity.x != 0 || velocity.z != 0)
        {
            PlayFootSound();
        }
    }

    void PlayFootSound()
    {
        StartCoroutine("PlayStepSound", footStepTimer);
    }

    IEnumerator PlayStepSound(float timer)
    {
        audioSource.Play();

        yield return new WaitForSeconds(timer);
    }
}
