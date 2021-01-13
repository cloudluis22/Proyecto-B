using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
  
    [SerializeField]
    private GameObject[] clouds;

    private int cloudIndex;

    [SerializeField]
    private float minPosX, maxPosX, minPosY, maxPosY;

    void Start()
    {
        StartCoroutine(Timer());
    }

    private void SpawnCloud(Vector3 cloudPosition)
    {
        cloudIndex = Random.Range(0, clouds.Length);
        Instantiate(clouds[cloudIndex], cloudPosition , gameObject.transform.rotation);
    }

    private Vector3 GeneratePos()
    {
       float positionX = Random.Range(minPosX, maxPosX);
       float positionY = Random.Range(minPosY, maxPosY);
       Vector3 cloudPosition = new Vector3(positionX, positionY, this.transform.position.z);
       return cloudPosition;
    }

    IEnumerator Timer()
    {
        SpawnCloud(GeneratePos());

        while(true)
        {
            yield return new WaitForSeconds(25);
            SpawnCloud(GeneratePos());
        }
        
    }

}
