using UnityEngine;

public class PlayerChain : MonoBehaviour
{
    public Transform playerA;
    public Transform playerB;
    public float maxDistance = 3f;
    public float pullStrength = 30f;

    Rigidbody rbA;
    Rigidbody rbB;

    void Start()
    {
        rbA = playerA.GetComponent<Rigidbody>();
        rbB = playerB.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 delta = playerB.position - playerA.position;
        float distance = delta.magnitude;

        if (distance > maxDistance)
        {
            Vector3 direction = delta.normalized;
            float excess = distance - maxDistance;

            rbA.AddForce(direction * excess * pullStrength, ForceMode.Force);
            rbB.AddForce(-direction * excess * pullStrength, ForceMode.Force);
        }
    }
}
