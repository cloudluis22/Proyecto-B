using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public Animator _animator;
    public PlayerController playerController;
    public PlayerCombat playerCombat;
    public PlayerAudio playerAudio;

    public Image[] hearts;
    public Sprite fullHearts;
    public Sprite emptyHeats;

    [Range(1, 5)]
    public int maxHealth = 3;
    private int currentHealth;

    private bool isDead;
    public bool IsDead
    {
        get
        {
            return isDead;
        }
        set
        {
            isDead = value;
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        playerController.GetComponent<PlayerController>();
        currentHealth = maxHealth;
        playerAudio = GetComponent<PlayerAudio>();
    }

     void Update()
    {     
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentHealth)
            {
                hearts[i].sprite = fullHearts;
            }
            else
            {
                hearts[i].sprite = emptyHeats;
            } 
            
            if (i < maxHealth)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    /// <summary>
    /// Método que se encargará de restarle salud al jugador una vez es atacado.
    /// </summary>
    public void TakeDamage(int damage, Vector3 direction)
    {
        currentHealth -= damage;
        playerController.PlayerKnockBack(direction);

       
            playerAudio.HurtSound();
        

        if (currentHealth <= 0)
        {
            Die();
        }    
    }

    /// <summary>
    /// Método que se encarga de realizar la muerte del jugador, y con el bool desactivar todas sus funciones.
    /// </summary>
    private void Die()
    {
        _animator.SetBool("IsDead", true);
        isDead = true;
    }
}
