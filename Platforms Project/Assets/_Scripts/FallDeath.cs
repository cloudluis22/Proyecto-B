using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDeath : MonoBehaviour
{
    public FadeIn fadeOut;

    [SerializeField]
    private AudioSource _audioSource;

    [SerializeField]
    private AudioClip scream;
    
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player")){
            fadeOut.FadeOutEffect();
            _audioSource.PlayOneShot(scream);
        }
    }
}
