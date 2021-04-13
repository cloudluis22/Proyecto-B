using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFOV : MonoBehaviour
{

    private EnemyAI enemy;
    private GameObject player;

    [SerializeField] LayerMask playerLayer;

    Vector3 playerDirection;


    private void Awake() 
    {
        enemy = gameObject.GetComponentInParent<EnemyAI>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
    
    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {          
            if(!Physics.Linecast(this.transform.position, player.transform.position, playerLayer, QueryTriggerInteraction.Ignore))
            {
                Debug.Log("Benny Detectado");
                enemy.IsSearching = true;
                enemy.PlayerSearchPosition = PlayerPosition();                
            }
            else
            {
                Debug.Log("Benny detras de una pared.");
                enemy.IsSearching = false;
            } 
        }
    }

    private Vector3 PlayerPosition()
    {
        return player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(this.transform.position, player.transform.position, Color.green);
    }

}