using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class EnemyController : MonoBehaviour
{
    public float lookRadius = 5f;

    private Transform target;
    private NavMeshAgent _agent;

    public float slerpLenght = 5f;

    public Animator _animator;

    private Rigidbody _rigidbody;

    public float attackRate = 1f;
    private float nextAttackTime;
    
    [Range(1, 4)]
    public int attackDamage;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask playerMask;

    public int maxHealth;
    private int currentHealth;

    [Range(0, 50)]
    public float knockBackForceBack;
    [Range(0, 50)]
    public float knockBackForceUp;

    public ParticleSystem blood;

    public PlayerHealth playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        
        _agent = GetComponent<NavMeshAgent>();
        
        target = GameObject.FindWithTag("Player").transform;
        
        _animator = GetComponent<Animator>();

        _rigidbody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        EnemyMove();    
    }

    /// <summary>
    /// Método que mira constantemente al jugador una vez está posicionado muy cerca de este.
    /// </summary>
    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * slerpLenght);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    /// <summary>
    /// Método que se encarga de realizar la animación del daño al jugador.
    /// </summary>
    private void EnemyAttackAnim()
    {
        if (Time.time >= nextAttackTime && playerHealth.IsDead == false)
        {
            _animator.SetTrigger("Attack");
            nextAttackTime = Time.time + 1f / attackRate;
        }
    }

    /// <summary>
    /// Método que se encarga del movimiento y rotación del enemigo.
    /// </summary>
    private void EnemyMove()
    {
        
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {
            _agent.speed = 2f;
            _agent.SetDestination(target.position);

            if (distance <= _agent.stoppingDistance)
            {
                _agent.speed = 0f;
                FaceTarget();
                EnemyAttackAnim();
            }
        }
        else
        {
           _agent.speed = 0f;
        }

           
           if (_agent.speed >= 0.0001f)
           {
              _animator.SetBool("IsMoving", true);
           }
           else
           {
              _animator.SetBool("IsMoving", false);
           }      
      
    }

    /// <summary>
    /// Método que permite al enemigo tomar daño del jugador.
    /// </summary>
    /// <param name="damage">Cantidad de daño inflingida por el jugador.</param>
    public void TakeDamage(int damage)
    {
        _agent.speed = 0f;
        
        currentHealth -= damage;

        blood.Play();
        
       if (currentHealth <= 0)
        {
            Die();
        }

        Vector3 direction = new Vector3(0f, knockBackForceUp, -knockBackForceBack);
        _rigidbody.AddRelativeForce(direction, ForceMode.Impulse);
    }

    /// <summary>
    /// Método que activa la muerte del enemigo una vez su vida llegue a cero.
    /// </summary>
    private void Die()
    {
        _rigidbody.isKinematic = true;
        
        Debug.Log("Enemy died!");
        _animator.SetBool("IsDead", true);

        GetComponent<Collider>().enabled = false;

        // Desactiva el script para ya no haga nada una vez muerto.
        this.enabled = false;
    }

    /// <summary>
    /// Método que se encargará de hacerle daño al jugador, llamado con un Animator Event durante la animación de ataque.
    /// </summary>
    private void EnemyAttack()
    {
        Collider[] hitPlayer = Physics.OverlapSphere(attackPoint.position, attackRange, playerMask);

        foreach(Collider player in hitPlayer)
        {
            Debug.Log(this.name + " " + "hit Benny");

            Vector3 hitDirection = player.transform.position - this.transform.position;
            hitDirection = hitDirection.normalized;
           
            player.GetComponent<PlayerHealth>().TakeDamage(attackDamage, hitDirection);
        }
    }
          
}
