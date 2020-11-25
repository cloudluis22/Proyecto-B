using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SocialPlatforms;

public class PlayerAudio : MonoBehaviour
{
    public static AudioSource _audioSource;

    private AudioClip concreteFootstep1;
    private AudioClip concreteFootstep2;
    private AudioClip concreteFootstep3;

    private AudioClip shortJumpSound;
    private AudioClip punchSound;
    private AudioClip hitSound;
    private AudioClip hurtSound;

    private AudioClip coinSound;

    [SerializeField]
    private AudioClip[] concreteArray = new AudioClip[3];


    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();

        concreteFootstep1 = Resources.Load<AudioClip>("Concrete_1");
        concreteFootstep2 = Resources.Load<AudioClip>("Concrete_2");
        concreteFootstep3 = Resources.Load<AudioClip>("Concrete_3");

        shortJumpSound = Resources.Load<AudioClip>("Short Jump");
        punchSound = Resources.Load<AudioClip>("Air Punch");
        hitSound = Resources.Load<AudioClip>("Damage Effect");
        hurtSound = Resources.Load<AudioClip>("Benny Damage");
        coinSound = Resources.Load<AudioClip>("Pickup Coin");

    }

    /// <summary>
    /// Método que reproduce el sonido de los pasos, llamado por un Animator Event en la animación de caminar.
    /// </summary>
    private void Footstep()
    {
        int randomIndex = Random.Range(0, concreteArray.Length);
        _audioSource.PlayOneShot(concreteArray[randomIndex]);
    }

    /// <summary>
    /// Metodo que reproduce el sonido del salto, llamado por un Animator Event en la animación de saltar.
    /// </summary>
    private void JumpSound()
    {
        _audioSource.PlayOneShot(shortJumpSound);
    }

    /// <summary>
    /// Método que reproduce el sonido de la moneda cuando una es recogida, llamado por el PlayerController cuando el jugador entra en contacto con una.
    /// </summary>
    public void CoinSound()
    {
        _audioSource.PlayOneShot(coinSound);
    }

    public void PunchSound()
    {
        _audioSource.PlayOneShot(punchSound);
    }

    public void HitSound()
    {
        _audioSource.PlayOneShot(hitSound);
    }
    
    public void HurtSound()
    {
        _audioSource.PlayOneShot(hurtSound);
    }
}
