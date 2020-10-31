using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public AudioSource jumpSound;
    
    // Start is called before the first frame update
    void Start()
    {
        jumpSound = GetComponent<AudioSource>();
    }

    private void JumpSound()
    {
        jumpSound.Play();
    }
}
