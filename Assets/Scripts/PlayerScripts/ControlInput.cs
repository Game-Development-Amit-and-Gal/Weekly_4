using UnityEngine;
using UnityEngine.InputSystem;

public class ControlInput : MonoBehaviour
{
    private Rigidbody rb;

    public float thrustForce = 10f;
    public float rotationForce = 5f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        var keyboard = Keyboard.current;

        if (keyboard == null)
            return;

        // --- MOVEMENT (UP/DOWN) ---
        if (keyboard.upArrowKey.isPressed)
        {
            rb.AddForce(transform.up * thrustForce, ForceMode.Force);
        }
        if (keyboard.downArrowKey.isPressed)
        {
            rb.AddForce(-transform.up * thrustForce, ForceMode.Force);
        }

        // --- ROTATION (LEFT/RIGHT) ---
        if (keyboard.leftArrowKey.isPressed)
        {
            rb.AddTorque(Vector3.forward * rotationForce, ForceMode.Force);
        }
        if (keyboard.rightArrowKey.isPressed)
        {
            rb.AddTorque(Vector3.back * rotationForce, ForceMode.Force);
        }
    }
}
