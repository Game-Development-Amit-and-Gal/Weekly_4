using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class moveUp : MonoBehaviour
{
    [SerializeField] private float movingSpeed = 10f;

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.up * movingSpeed * Time.deltaTime;



    }
}
