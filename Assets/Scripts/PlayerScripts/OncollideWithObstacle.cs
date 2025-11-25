using UnityEngine;
using UnityEngine.SceneManagement;

public class OncollideWithObstacle : MonoBehaviour
{
    private bool isLanded = false;   // Tracks whether the object has landed on the planet

    // Called when this object collides with another collider
    private void OnCollisionEnter(Collision collision)
    {
        // --- Collision with an obstacle ---
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            // Destroy this object and restart the scene
            Destroy(this.gameObject);
            SceneManager.LoadScene("RestartScene");   // Scene name is fixed (not a magic number)
        }

        // --- Collision with the planet ---
        else if (collision.gameObject.CompareTag("Planet"))
        {
            Debug.Log("Landed!");
            isLanded = true;    // Mark as landed so gravity stops pulling

            Rigidbody rb = GetComponent<Rigidbody>();

            // Stop all movement on landing
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;

            // Completely freeze the body so it doesn't move anymore
            rb.constraints = RigidbodyConstraints.FreezeAll;

            // Reload the restart scene
            SceneManager.LoadScene("RestartScene");   // Same scene as above
        }
    }

    // Getter used by GravityAdjustment to check if landing occurred
    public bool IsLanded()
    {
        return isLanded;
    }
}
