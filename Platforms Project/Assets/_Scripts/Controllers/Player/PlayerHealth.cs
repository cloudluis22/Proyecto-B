using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

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

    private Rigidbody[] ragdollParts;
    private Animator _animator;

    private CinemachineImpulseSource shakeSource;

    private void Awake() {
        shakeSource = GetComponent<CinemachineImpulseSource>();
    }
    
    void Start()
    {
        _animator = GetComponent<Animator>();
        currentHealth = maxHealth;
        _healthBar.SetMaxHealth(maxHealth);
        ragdollParts = transform.GetComponentsInChildren<Rigidbody>();
        SetRagdoll(false);

        foreach(Rigidbody rb in ragdollParts){
            rb.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
        }

    }

     public void SetRagdoll(bool enabled){
            
            _animator.enabled = !enabled;
            bool isKinematic = !enabled;
            foreach(Rigidbody rb in ragdollParts){
            rb.isKinematic = isKinematic;
            
            if(enabled)
            rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
        }  
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        _healthBar.SetHealth(currentHealth);
        shakeSource.GenerateImpulse();

        if(currentHealth <= 0){
            Die();
        }
    }

    private void Die()
    {
           _animator.SetBool("IsDead", true);
           SetRagdoll(true);
           this.gameObject.GetComponent<PlayerController>().enabled = false;
           
    }

}