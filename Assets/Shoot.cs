using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float raycastLength = 50f;
    public float shootingRate = 0.5f;
    public GameObject explosionEffect;
    public AudioClip shootSound;
    public AudioClip bombSound;
    public AudioClip splitSound;
    public AudioClip jumpSound;

    private float nextShootTime = 0f;

    
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0) && Time.time > nextShootTime)
        {
            
            nextShootTime = Time.time + shootingRate;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, raycastLength))
            {
                Enemy enemy = hit.transform.GetComponent<Enemy>();
                if (enemy != null)
                {
                    
                    if (enemy is BombEnemy)
                    {
                        enemy.TakeDamage(1);
                        AudioSource.PlayClipAtPoint(bombSound, hit.transform.position);

                    }
                    else if (enemy is SplitEnemy)
                    {
                        enemy.TakeDamage(1);
                        AudioSource.PlayClipAtPoint(splitSound, hit.transform.position);
                    }
                    else if (enemy is JumpEnemy)
                    {
                        enemy.TakeDamage(1);
                        AudioSource.PlayClipAtPoint(jumpSound, hit.transform.position);
                    }

                    
                    
                }
            }

            
            AudioSource.PlayClipAtPoint(shootSound, transform.position);
        }
    }
}
