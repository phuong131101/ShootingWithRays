using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitEnemy : Enemy
{

    public GameObject bigPrefab;
    public GameObject smallPrefab;
    public float bigSize = 1.5f;
    public float smallSize = 0.5f;
    public float spawnChance = 0.3f;

    

    public void TakeDamage()
    {
        
        
    

        
        if (Random.value < spawnChance)
        {
            GameObject newEnemy = Instantiate(bigPrefab, transform.position, Quaternion.identity);
            newEnemy.transform.localScale = Vector3.one * bigSize;
            newEnemy.GetComponent<Rigidbody>().mass = bigSize;
        }
        else
        {
            for (int i = 0; i < 2; i++)
            {
                GameObject newEnemy = Instantiate(smallPrefab, transform.position, Quaternion.identity);
                newEnemy.transform.localScale = Vector3.one * smallSize;
                newEnemy.GetComponent<Rigidbody>().mass = smallSize;
            }
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
