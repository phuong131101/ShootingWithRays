using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float move_Speed = 5f;
    public float jumpHeight = 2f;
    public float gravity = -9.81f;

    public LayerMask groundMask;
    public float groundCheckDistance = 0.1f;


    CharacterController controller;
    Vector3 velocity = Vector3.zero;
    bool isGrounded;

    bool GameisPaused = false;

    public int maxHealth = 100;
    public int currentHealth;

    public int edibleCount = 0;

    public AudioSource successSound;
    public AudioSource failureSound;

    void Start()
    {

        controller = GetComponent<CharacterController>();

        currentHealth = maxHealth;

    }

    void Update()
    {

        isGrounded = controller.isGrounded;

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 0f;
        }

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 move = transform.right * horizontalInput + transform.forward * verticalInput;

        if (controller.enabled) // check if controller is enabled
        {
            controller.Move(move * move_Speed * Time.deltaTime);
        }
       
        // Handle jumping
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        // Apply velocity
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!GameisPaused)
            {
                Time.timeScale = 0f;
                GameisPaused = true;
            }
            else
            {
                Time.timeScale = 1f;
                GameisPaused = false;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Food"))
        {
            Destroy(other.gameObject);
            successSound.Play();
            edibleCount++;
            Debug.Log("Player has collected " + edibleCount + " edible items so far.");
        }
        else if (other.gameObject.CompareTag("Not Food"))
        {
            currentHealth -= 20;
            failureSound.Play();
            Debug.Log("Player has taken damage! Current health: " + currentHealth);
            if (currentHealth <= 0)
            {
                GameOver();
            }
        }
    }
    void GameOver()
    {
        Debug.Log("Game over!");
        UnityEditor.EditorApplication.isPlaying = false;
    }

}

