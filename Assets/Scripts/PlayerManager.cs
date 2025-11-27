using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    public Vector3 startpos;
    private Rigidbody rb;

    private void Start()
    {
        startpos = transform.position;
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Enemy")) { 
            Die();
        }
    }

    public void Die()
{
    if (rb != null)
    {
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }
    transform.position = startpos;

    var players = GameObject.FindGameObjectsWithTag("Player");
    foreach (var p in players)
    {
        if (p == gameObject) continue;

        var pm = p.GetComponent<PlayerManager>();
        if (pm != null)
        {
            var otherRb = p.GetComponent<Rigidbody>();
            if (otherRb != null)
            {
                otherRb.linearVelocity = Vector3.zero;
                otherRb.angularVelocity = Vector3.zero;
            }
            p.transform.position = pm.startpos;
        }
    }
}
}