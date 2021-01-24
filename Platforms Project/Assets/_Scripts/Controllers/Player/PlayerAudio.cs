using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SocialPlatforms;

public class PlayerAudio : MonoBehaviour
{
    public AudioSource _audioSource;
    public AudioSource _audioSource2;
    public AudioSource _audioSource3;

    //Arreglo de pasos de concreto.
    [SerializeField]
    private AudioClip[] concreteArray = new AudioClip[3];

    [SerializeField]
    private AudioClip[] grassArray;
    
    [SerializeField]
    private AudioClip[] sandArray;

    //Variables de salto largo y corto.
    [SerializeField]
    private AudioClip shortJumpSound, longJumpSound;

    //Combate: sonidos de golpear en el aire, golpear, ser golpeado.
    [SerializeField]
    private AudioClip punchSound, hitSound, deathSound;

    [SerializeField]
    private AudioClip[] hurtSounds;

    //Sonido de recoger monedas.
    [SerializeField]
    private AudioClip coinSound;

    [SerializeField]
    private float longJumpMinPitch = 0.65f, longJumpMaxPitch = 1.2f;

    [SerializeField]
    private float shortJumpMinPitch = 0.7f, shortJumpMaxPitch = 1.5f;

    [SerializeField]
    private AudioClip impaleSound;

    private int groundIndex;
    int randomIndex;

    private void OnControllerColliderHit(ControllerColliderHit hit) {
       if(hit.transform.tag == "Footsteps/Grass")
       {
           groundIndex = 1;
       }
       else if(hit.transform.tag == "Footsteps/Wooden or Concrete")
       {
           groundIndex = 2;
       }
       else if(hit.transform.tag == "Footsteps/Sand"){
           groundIndex = 3;
       }
    }

    /// <summary>
    /// Método que reproduce el sonido de los pasos, llamado por un Animator Event en la animación de caminar.
    /// </summary>
    private void Footstep()
    {
        switch(groundIndex){
            case 1:
                 randomIndex = Random.Range(0, grassArray.Length);
                _audioSource3.PlayOneShot(grassArray[randomIndex], 0.65f);
            break;

            case 2:
                 randomIndex = Random.Range(0, concreteArray.Length);
                _audioSource3.PlayOneShot(concreteArray[randomIndex], 0.25f);
            break;

            case 3:
                randomIndex = Random.Range(0, sandArray.Length);
                _audioSource3.PlayOneShot(sandArray[randomIndex], 0.65f);
            break;
        }

    }

    /// <summary>
    /// Método que reproduce el sonido del salto alto, llamado por un Animator Event en la animación de saltar alto.
    /// </summary>
    private void LongJumpSound()
    {
        float randomPitch = Random.Range(longJumpMinPitch, longJumpMaxPitch);
        _audioSource.pitch = randomPitch;
        _audioSource.PlayOneShot(longJumpSound, 0.2f);
    }

    /// <summary>
    /// Método que reproduce el sonido del salto corto, llamado por un Animator Event en la animación de saltar de forma corta.
    /// </summary>
    private void ShortJumpSound()
    {
        float randomPitch = Random.Range(shortJumpMinPitch, shortJumpMaxPitch);
        _audioSource.pitch = randomPitch;
        _audioSource.PlayOneShot(shortJumpSound, 0.2f);
    }

    /// <summary>
    /// Método que reproduce el sonido de la moneda cuando una es recogida, llamado por el PlayerController cuando el jugador entra en contacto con una.
    /// </summary>
    public void CoinSound(float pitch)
    {
        _audioSource2.pitch = pitch;
        _audioSource2.PlayOneShot(coinSound, 0.1f);
    }

   /// <summary>
   /// Método que reproduce el sonido de el aire al golpear cada vez que el jugador decide golpear.
   /// </summary>
    public void PunchSound()
    {
        _audioSource.PlayOneShot(punchSound);
    }

    /// <summary>
    /// Método que reproduce el sonido del golpeo una vez el puño impacta a un enemigo con éxito.
    /// </summary>
    public void HitSound()
    {
        _audioSource.PlayOneShot(hitSound);
    }
    
   /// <summary>
   /// Método que reproduce el sonido de dolor si el jugador es golpeado con éxito por algún enemigo.
   /// </summary>
    public void HurtSound()
    {
        int randomIndex = Random.Range(0, hurtSounds.Length);
        _audioSource.pitch = 1f;
        _audioSource.PlayOneShot(hurtSounds[randomIndex]);
    }

/// <summary>
///  Método que reproduce el sonido de muerte del jugador.
/// </summary>
    public void DieSound()
    {
        _audioSource.pitch = 1f;
        _audioSource.PlayOneShot(deathSound);
    }

/// <summary>
/// Sonido del impalamiento.
/// </summary>
    public void ImpaleSound(){
        _audioSource3.pitch = 1f;
        _audioSource.PlayOneShot(impaleSound, 0.85f);
    }
}
