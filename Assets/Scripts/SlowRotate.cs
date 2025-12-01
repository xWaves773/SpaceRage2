using UnityEngine;

public class SlowRotate : MonoBehaviour
{
    [Tooltip("Rotation speed in degrees per second")]
    public float rotationSpeed = 20f;

    void Update()
    {
        // Rotate around the Y-axis at a constant speed
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f, Space.Self);
    }
}
