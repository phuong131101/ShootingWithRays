using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstaintiatingScript : MonoBehaviour
{
    public GameObject G2_Red;
    public KeyCode spawnKey = KeyCode.C;
    public KeyCode gravityKey = KeyCode.G;
    public GameObject ObjectSpawner;
    public KeyCode tiltLeftKey = KeyCode.A;
    public KeyCode tiltRightKey = KeyCode.D;
    public float tilteAngle = 15f;

    void Update()
    {
        if (Input.GetKeyDown(spawnKey))
        {
            Vector3 randomPosition = new Vector3(Random.Range(-5f, 5f), Random.Range(0f, 5f), Random.Range(-5f, 5f)); // modify the range as needed
            GameObject spawnedObject = Instantiate(G2_Red, randomPosition, Quaternion.identity);
            spawnedObject.transform.parent = ObjectSpawner.transform;
        }

        if (Input.GetKeyDown(gravityKey))
        {
            Rigidbody[] rigidbodies = ObjectSpawner.GetComponentsInChildren<Rigidbody>();
            foreach (Rigidbody rb in rigidbodies)
            {
                rb.useGravity = true;
            }
        }
        if (Input.GetKey(tiltLeftKey))
        {
            Quaternion newRotation = Quaternion.Euler(0f, -tilteAngle * Time.deltaTime, 0f);
            ObjectSpawner.transform.rotation *= newRotation;
        }

        if (Input.GetKey(tiltRightKey))
        {
            Quaternion newRotation = Quaternion.Euler(0f, tilteAngle * Time.deltaTime, 0f);
            ObjectSpawner.transform.rotation *= newRotation;
        }
        if (Input.GetMouseButtonDown(1))
        {
            foreach (Transform child in ObjectSpawner.transform)
            {
                Destroy(child.gameObject);
            }
        }
    }

}
