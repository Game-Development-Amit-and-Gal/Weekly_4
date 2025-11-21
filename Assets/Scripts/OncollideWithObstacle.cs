using UnityEngine;
using UnityEngine.SceneManagement;

public class OncollideWithObstacle : MonoBehaviour
{
    private bool isLanded = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene("RestartScene");
        }
        else if (collision.gameObject.CompareTag("Planet"))
        {
            Debug.Log("Landed!");
            isLanded = true;

            Rigidbody rb = GetComponent<Rigidbody>();
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;

            rb.constraints = RigidbodyConstraints.FreezeAll;
            SceneManager.LoadScene("RestartScene");
        }
    }

    public bool IsLanded()
    {
        return isLanded;
    }
}
