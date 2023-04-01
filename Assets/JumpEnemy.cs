using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpEnemy : Enemy
{
    public Rigidbody rb;
    public float jumpForce = 10f;
    public float jumpDuration = 1f;

    private bool isJumping = false;



    public void TakeDamage()
    {
        if (!isJumping)
        {

            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isJumping = true;


            Invoke("StopJumping", jumpDuration);
        }
    }

    private void StopJumping()
    {
        isJumping = false;




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
