using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform playerTransform;  
    public float moveSpeed = 2f;       

    void Update()
    {
        Vector3 direction = playerTransform.position - transform.position; 
        direction.Normalize();                                              

        transform.position += direction * moveSpeed * Time.deltaTime;       
    }
}

