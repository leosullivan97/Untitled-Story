using UnityEngine;

namespace UntitledStory {
    public class Collectible : Entity {
        [SerializeField] private CollectibleData collectibleData;

        private void OnTriggerEnter(Collider other) {
            // Check if the interacting object has the "Player" tag
            if (other.CompareTag("Player") && CompareTag("Collectible")) {
                HandleCollectiblePickup();
            }
        }

        private void OnCollisionEnter(Collision collision) {
            // Check if the interacting object has the "Player" tag
            if (collision.collider.CompareTag("Player") && CompareTag("Collectible")) {
                HandleCollectiblePickup();
            }
        }

        private void HandleCollectiblePickup() {
            // Add to the player's score via the GameManager
            GameManager.Instance.AddScore(collectibleData.scoreProgress);

            // Play sound effect if assigned
            if (collectibleData.collectSound != null) {
                AudioSource.PlayClipAtPoint(collectibleData.collectSound, transform.position);
            }

            // Destroy the collectible after being collected
            Destroy(gameObject);
        }
    }
}
