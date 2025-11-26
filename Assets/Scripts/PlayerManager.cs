using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private GameMaster gm;
    public Vector3 startpos;
   

    private void Start()
    {
        startpos = transform.position;
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            Die();
        }
    }

    public void Die()
    {
        transform.position = gm.lastCheckPointPos;
    }
}
