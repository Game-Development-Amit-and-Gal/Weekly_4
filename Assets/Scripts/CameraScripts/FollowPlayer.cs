using UnityEngine;

[RequireComponent(typeof(Transform))]
public class FollowPlayer : MonoBehaviour
{
    // The transform of the player this object should follow.
    [SerializeField] private Transform playerTransform;

    // Positional offset from the player's position (customizable per scene).
    [SerializeField] private Vector3 offset;

    // Lerp smoothing factor for following movement (replaces magic number 0.1f).
    [SerializeField] private float followSmoothness = 0.1f;

    private void LateUpdate()
    {
        // Only follow if a player transform is assigned.
        if (playerTransform != null)
        {
            // Target position is player's position + offset.
            Vector3 desiredPos = playerTransform.position + offset;

            // Smoothly interpolate from current position to target.
            transform.position = Vector3.Lerp(transform.position, desiredPos, followSmoothness);

            // Rotate to look at the player.
            transform.LookAt(playerTransform);
        }
    }
}
