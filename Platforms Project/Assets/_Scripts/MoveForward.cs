using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    [SerializeField]
    private float speed = 0.05f;

    void Update()
    {
        this.transform.Translate(speed * Vector3.forward * Time.deltaTime);
    }
}
