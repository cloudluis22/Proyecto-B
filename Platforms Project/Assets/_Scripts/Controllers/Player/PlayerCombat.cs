using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCombat : MonoBehaviour
{
    public Animator _animator;
    private PlayerControls _playerControls;
    public PlayerController playerController;

    public float attackRate = 2f;
    private float nextAttackTime;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayer;

    public int attackDamage = 1;
    public bool isPunching;

    public PlayerHealth health;

    public PlayerAudio playerAudio;

    private void Awake()
    {
        _playerControls = new PlayerControls();
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _playerControls.Enable();
    }

    private void OnDisable()
    {
        _playerControls.Disable();
    }

    void Start()
    {
        health.GetComponent<PlayerHealth>();
    }

    
    void Update()
    { 
          if(health.IsDead == false)
            AttackAnim();
    }

    /// <summary>
    /// Método que reproduce la animación de ataque, tambien agrega un pequeño contador de refrescamiento para evitar abusar del click.
    /// </summary>
    public void AttackAnim()
    {
            if (Time.time >= nextAttackTime)
            {
                if (_playerControls.Land.Attack.triggered && playerController._animationStates == AnimationStates.standing)
                {
                    _animator.SetTrigger("Punch");
                    nextAttackTime = Time.time + 1f / attackRate;
                    isPunching = true;
                }
            }  
    }

    private void IsNotPunchingAnymore()
    {
        isPunching = false;
    }

    /// <summary>
    /// Método que se encarga de realizar daño a los enemigos en un cierto rango de ataque.
    /// </summary>
    public void PlayerAttack()
    {
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayer);

        foreach(Collider enemy in hitEnemies)
        {
            Debug.Log("Benny hit " + enemy.name + " and caused " + attackDamage + " damage");
            enemy.GetComponent<EnemyController>().TakeDamage(attackDamage);
            playerAudio.HitSound();
        }
       
    }

}



