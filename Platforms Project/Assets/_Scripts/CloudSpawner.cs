using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    [SerializeField]
    private float startPosition;
    
    [SerializeField]
    private float startHeight;

    [SerializeField]
    private GameObject[] clouds;

    private int cloudIndex;

    private float posX, posY, posZ;

    void Start()
    {
        cloudIndex = Random.Range(0, clouds.Length);
        Instantiate(clouds[cloudIndex], transform.position = new Vector3(0, 0, 0), transform.rotation);
    }
}
