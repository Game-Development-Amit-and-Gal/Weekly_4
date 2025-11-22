using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class GravityAdjustment : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float gravityScale = 20f;
    [SerializeField] private Transform planet;
    private OncollideWithObstacle landing;

    [SerializeField] private float minPull = 10f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        landing = GetComponent<OncollideWithObstacle>();

    }



    private void FixedUpdate()
    {
        if (!rb || !planet || !this) return;
        if (landing != null && landing.IsLanded()) return;


        Vector3 direction = (planet.position - transform.position).normalized;
        float distance = Vector3.Distance(planet.position, transform.position);
        float gravity = gravityScale / distance * distance;

        rb.AddForce(direction * (gravity + minPull), ForceMode.Acceleration);
    }
}
