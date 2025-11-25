using UnityEngine;

public class moveUp : MonoBehaviour
{
    // Movement speed for how fast the object moves upward.
    [SerializeField] private float movingSpeed = 10f;

    void Update()
    {
        // Move the object upward every frame:
        // Vector3.up = (0,1,0)
        // Multiply by speed and deltaTime to keep movement framerate-independent.
        transform.position += Vector3.up * movingSpeed * Time.deltaTime;
    }
}
