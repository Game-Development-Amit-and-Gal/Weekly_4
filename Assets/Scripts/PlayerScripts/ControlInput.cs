using UnityEngine;
using UnityEngine.InputSystem;

public class ControlInput : MonoBehaviour
{
    private Rigidbody rb;   // Reference to the Rigidbody component

    // Movement forces exposed for tuning in Inspector
    [SerializeField] private float thrustForce = 10f;      // Forward / upward thrust strength
    [SerializeField] private float rotationForce = 5f;     // Torque strength for rotation

    // Magic numbers turned into fields
    [SerializeField] private ForceMode forceMode = ForceMode.Force;   // Force mode used for all forces

    private void Start()
    {
        // Cache Rigidbody for performance / safety
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        var keyboard = Keyboard.current;

        // Safety check: Keyboard may be null if not focused
        if (keyboard == null)
            return;

        // ============================
        //       MOVEMENT INPUT
        // ============================

        // Move upward (thrust)
        if (keyboard.upArrowKey.isPressed)
        {
            rb.AddForce(transform.up * thrustForce, forceMode);
        }

        // Move downward (reverse thrust)
        if (keyboard.downArrowKey.isPressed)
        {
            rb.AddForce(-transform.up * thrustForce, forceMode);
        }

        // ============================
        //       ROTATION INPUT
        // ============================

        // Rotate left (clockwise torque)
        if (keyboard.leftArrowKey.isPressed)
        {
            rb.AddTorque(Vector3.forward * rotationForce, forceMode);
        }

        // Rotate right (counter-clockwise torque)
        if (keyboard.rightArrowKey.isPressed)
        {
            rb.AddTorque(Vector3.back * rotationForce, forceMode);
        }
    }
}
