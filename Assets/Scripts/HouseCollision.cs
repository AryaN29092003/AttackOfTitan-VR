using UnityEngine;

public class HouseCollision : MonoBehaviour
{
    public ScoreManager scoreManager; // Reference to the ScoreManager script
    public int pointsPerHit = 10; // Points added per rock hit
    public GameObject explosionParticlePrefab; // Reference to the Particle System prefab
    public float explosionDuration = 2.0f; // How long the particle system should last

    public AudioClip explosionSound;

    // Detect collision
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the object that hit is tagged as "Rock"
        if (collision.gameObject.CompareTag("Rock"))
        {
            // Add score using the ScoreManager
            scoreManager.AddScore(pointsPerHit);

             // Instantiate the explosion particle effect at the house's position and rotation
            GameObject explosion = Instantiate(explosionParticlePrefab, transform.position, Quaternion.identity);

            Destroy(gameObject);

            AudioSource.PlayClipAtPoint(explosionSound, transform.position);

            // Destroy the explosion particle system after the explosionDuration
            Destroy(explosion, explosionDuration); 
        }
    }
}
