using UnityEngine;

public class SpikePlatform : MonoBehaviour
{
    [Header("Spike Settings")]
    public int damage = 10;
    public float knockbackForce = 10f;
    public float knockbackDuration = 0.2f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            // Dano ao player
            /*PlayerHealth health = collision.collider.GetComponent<PlayerHealth>();
            if (health != null)
                health.TakeDamage(damage);*/

            // Knockback
            Move knock = collision.collider.GetComponent<Move>();
            if (knock != null)
            {
                Vector3 dir = (collision.collider.transform.position - transform.position).normalized;
                dir.x = 0;
                dir = dir.normalized;
                knock.ApplyKnockback(dir, knockbackForce, knockbackDuration);
            }
        }
    }
}
