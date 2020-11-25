using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SocialPlatforms;

public class PlayerAudio : MonoBehaviour
{
    public AudioSource _audioSource;

    //Movimiento:

    //Arreglo de pasos de concreto.
    [SerializeField]
    private AudioClip[] concreteArray = new AudioClip[3];

    //Variables de salto largo y corto.
    [SerializeField]
    private AudioClip shortJumpSound, longJumpSound;

    //Combate: sonidos de golpear en el aire, golpear, ser golpeado.
    [SerializeField]
    private AudioClip punchSound, hitSound, hurtSound;

    //Sonido de recoger monedas.
    [SerializeField]
    private AudioClip coinSound;

    
    //Variables del valor flotantes del tono, el cual irá variando entre el mínimo y el máximo.
    [SerializeField]
    private float minPitch = 0.75f, maxPitch = 1.5f;

    /// <summary>
    /// Método que reproduce el sonido de los pasos, llamado por un Animator Event en la animación de caminar.
    /// </summary>
    private void Footstep()
    {
        int randomIndex = Random.Range(0, concreteArray.Length);
        _audioSource.pitch = 1f;
        _audioSource.PlayOneShot(concreteArray[randomIndex], 0.25f);
    }

    /// <summary>
    /// Método que reproduce el sonido del salto alto, llamado por un Animator Event en la animación de saltar alto.
    /// </summary>
    private void LongJumpSound()
    {
        float randomPitch = Random.Range(minPitch, maxPitch);
        _audioSource.pitch = randomPitch;
        _audioSource.PlayOneShot(longJumpSound);
    }

    /// <summary>
    /// Método que reproduce el sonido del salto corto, llamado por un Animator Event en la animación de saltar de forma corta.
    /// </summary>
    private void ShortJumpSound()
    {
        float randomPitch = Random.Range(minPitch, maxPitch);
        _audioSource.pitch = randomPitch;
        _audioSource.PlayOneShot(shortJumpSound);
    }

    /// <summary>
    /// Método que reproduce el sonido de la moneda cuando una es recogida, llamado por el PlayerController cuando el jugador entra en contacto con una.
    /// </summary>
    public void CoinSound()
    {
        _audioSource.PlayOneShot(coinSound);
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
        _audioSource.PlayOneShot(hurtSound);
    }
}
