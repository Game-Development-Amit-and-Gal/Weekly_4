using UnityEngine;
using static UnityEngine.GraphicsBuffer;

[RequireComponent (typeof(Transform))]
public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Vector3 offset;


    void LateUpdate()
    {
        if (playerTransform != null)
        {
            Vector3 desiredPos = playerTransform.position + offset;
            transform.position = Vector3.Lerp(transform.position, desiredPos, 0.1f);
            transform.LookAt(playerTransform);
        }
    }

}
