using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombEnemy : Enemy
{

    public float explosionForce = 100f;
    public float explosionRadius = 10f;
    public ParticleSystem explosionEffect;



    public void TakeDamage()
    {

        Instantiate(explosionEffect, transform.position, Quaternion.identity);


        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider collider in colliders)
        {
            Rigidbody rb = collider.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius);
            }
        }





        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}