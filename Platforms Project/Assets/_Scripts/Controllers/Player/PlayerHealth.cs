using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private int maxHealth = 20;

    private int currentHealth;
    public int CurrentHealth
    {
        get => currentHealth;
        set => currentHealth = value;
    }

    public HealthBar _healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        _healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        _healthBar.SetHealth(currentHealth);
    }
    private void Update() {
        Die();
    }

    private void Die()
    {
        if(currentHealth <= 0)
        {
           this.gameObject.GetComponent<Animator>().enabled = false;
        }

    }
}
