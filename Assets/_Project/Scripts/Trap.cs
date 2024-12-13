using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [Header("Trap Settings")]
    [SerializeField] private AudioClip springSound; // Optional: Sound effect for the trap
    [SerializeField] private float bounceForce = 10f; // Force applied to bounce the player

    // Triggered when another collider enters the trap's collider
    private void OnTriggerEnter(Collider collision)
    {
        // Check if the colliding object has the "Player" tag
        if (collision.gameObject.CompareTag("Player"))
        {
            HandlePlayerBounce(collision.gameObject);
        }
    }

    // Applies a bounce effect to the player if they enter the trap
    private void HandlePlayerBounce(GameObject player)
    {
        Rigidbody rb = player.GetComponent<Rigidbody>(); // Access the player's Rigidbody component

        // Only proceed if the player has a Rigidbody
        if (rb)
        {
            if (springSound != null)
            {
                AudioSource.PlayClipAtPoint(springSound, transform.position); // Play trap sound
            }

            rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z); // Reset player's vertical velocity

            rb.AddForce(Vector3.up * bounceForce, ForceMode.Impulse); // Apply bounce force upwards
        }
    }
}
