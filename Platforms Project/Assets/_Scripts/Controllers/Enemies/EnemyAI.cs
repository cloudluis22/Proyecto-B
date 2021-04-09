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

    private Vector3 startingPosition, destinationPoint;

    [SerializeField] private float enemyShortRange, enemyMediumRange, enemyLargeRange;
    private float enemyRange;

    [SerializeField] private float enemyWalkRangeX, enemyWalkRangeZ;

    private bool patrolPointSet;

    public PlayerController playerState;
    


    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.Find("Player").transform;
        playerState = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    private void Start() {
        startingPosition = this.transform.position;
        agent = GetComponent<NavMeshAgent>();
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

    private Vector3 NewPatrollingPoint()
    {

        float walkRangeX = Random.Range(-enemyWalkRangeX, enemyWalkRangeX);
        float walkRangeZ = Random.Range(-enemyWalkRangeZ, enemyWalkRangeZ);

        Vector3 walkPoint = new Vector3(walkRangeX + transform.position.x, 0f, walkRangeZ + transform.position.z);

        return walkPoint;

    }
    private void EnemyPatrol()
    {

        if(!patrolPointSet)
        {
            destinationPoint = NewPatrollingPoint();
            patrolPointSet = true;
        }
        else
        {
            agent.SetDestination(destinationPoint);
            transform.rotation = Quaternion.Lerp(transform.localRotation, Quaternion.LookRotation(destinationPoint), Time.deltaTime * 0.2f);
        }

        Vector3 walkPointDistance = (transform.position - destinationPoint);
        Debug.Log(walkPointDistance.magnitude);

        if(walkPointDistance.magnitude < 1f)
        {
            patrolPointSet = false;
        }

    }

    private void SetEnemyState()
    {
        switch(_enemyState)
        {
            case EnemyStates.Patrolling:
                EnemyPatrol();
             break;


        }
    }


}
