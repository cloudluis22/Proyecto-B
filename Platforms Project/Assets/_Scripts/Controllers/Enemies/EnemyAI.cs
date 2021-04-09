using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyAI : MonoBehaviour
{

    enum EnemyStates
    {
        Patrolling,
        Chasing,
        Attacking,
        Searching
    }

    private NavMeshAgent agent;

    private EnemyStates _enemyState;

    public Transform player;
    [SerializeField ]private LayerMask groundMask, playerMask;

    private int destinationPoint = 0;

    [SerializeField] private float enemyShortRange, enemyMediumRange, enemyLargeRange;
    private float enemyRange;

    private bool patrolPointSet;

    public PlayerController playerState;

    [SerializeField] private Transform[] wayPoints;

    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.Find("Player").transform;
        playerState = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    private void Start() 
    {
        agent = GetComponent<NavMeshAgent>();
        //agent.autoBraking = false;
        agent.SetDestination(wayPoints[0].position);
    }

    // Update is called once per frame
    void Update()
    {
        SetEnemyState();
        SetEnemyRange();
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, enemyRange);
    }

    /// <summary>
    /// Método que define el rango de detección del enemigo según el estado del jugador.
    /// </summary>
    private void SetEnemyRange()
    {   
               
        if(playerState._animationStates == AnimationStates.crouching || playerState._animationStates == AnimationStates.crouchWalking) // Si está agachado o moviendose agachado.
        {
            enemyRange = enemyShortRange;
        }      
        else if(playerState._animationStates == AnimationStates.standing || playerState._animationStates == AnimationStates.jogging) // Si está de pie o trotando.
        {
            enemyRange = enemyMediumRange;
        }    
        else if(playerState._animationStates == AnimationStates.running) // Si está corriendo.
        {
            enemyRange = enemyLargeRange;
        }
        else
        {
            enemyRange = enemyMediumRange; // Cualquier otra cosa.
        }

        if(!Physics.CheckSphere(this.transform.position, enemyRange, playerMask))
        {
            _enemyState = EnemyStates.Patrolling;
        }
        else
        {
            _enemyState = EnemyStates.Chasing;
        } 

    }

    private void EnemyPatrol()
    {
        if(agent.remainingDistance < 1.5f)
        {
            EnemyPointMove();
        }
    }

    private void EnemyPointMove()
    {
        destinationPoint = (destinationPoint + 1) % wayPoints.Length;
        agent.SetDestination(wayPoints[destinationPoint].position);
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
        transform.localRotation = Quaternion.Lerp(transform.rotation, player.rotation, Time.deltaTime * 5f);
    }

    private void SetEnemyState()
    {
        switch(_enemyState)
        {
            case EnemyStates.Patrolling:
                EnemyPatrol();
            break;

            case EnemyStates.Chasing:
                ChasePlayer();
            break;            
        }
    }

}