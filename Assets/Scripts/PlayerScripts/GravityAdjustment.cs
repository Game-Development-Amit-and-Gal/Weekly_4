using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class GravityAdjustment : MonoBehaviour
{
    // Rigidbody used for applying custom gravity
    [SerializeField] private Rigidbody rb;

    // Controls the strength of the gravity attraction
    [SerializeField] private float gravityScale = 20f;

    // The object acting as the "planet" the player is pulled toward
    [SerializeField] private Transform planet;

    // Optional component that indicates if the player has landed
    private OncollideWithObstacle landing;

    // Ensures gravity force is never zero — small minimum pull
    [SerializeField] private float minPull = 10f;

    private void Start()
    {
        // Cache Rigidbody component (required)
        rb = GetComponent<Rigidbody>();

        // Cache landing detector if the object has one
        landing = GetComponent<OncollideWithObstacle>();
    }

    private void FixedUpdate()
    {
        // Safety checks: must have rigidbody, planet, and object must not be destroyed
        if (!rb || !planet || !this) return;

        // If the object has landed, stop applying gravity
        if (landing != null && landing.IsLanded()) return;

        // Compute normalized direction toward the planet
        Vector3 direction = (planet.position - transform.position).normalized;

        // Compute distance between object and planet
        float distance = Vector3.Distance(planet.position, transform.position);

        // Gravity calculation (inverse square relation)
        float gravity = gravityScale / (distance * distance);

        // Apply gravity force toward planet
        rb.AddForce(direction * (gravity + minPull), ForceMode.Acceleration);
    }
}
