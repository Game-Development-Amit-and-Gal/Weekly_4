using UnityEngine;
using UnityEngine.SceneManagement;

public class OutOfBounds : MonoBehaviour
{
    public Transform planet;

    void Update()
    {
        float dist = Vector3.Distance(transform.position, planet.position);
        float safeRadius = planet.localScale.x * 200;  // adjust factor if needed

        if (dist > safeRadius)
        {
            SceneManager.LoadScene("RestartScene");
        }
    }
}
