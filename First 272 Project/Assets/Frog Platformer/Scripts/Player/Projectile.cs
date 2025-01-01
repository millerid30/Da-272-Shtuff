using UnityEngine;
public class Projectile : MonoBehaviour
{
    [SerializeField] private float projectileDamage = 10f;
    [SerializeField] private float projectileSpeed = 10f;
    [SerializeField] private float destroyTime = 1f;
    [SerializeField] private LayerMask whatDestroysProjectile;

    private Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        SetVelocity();
        SetDestroyTime();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((whatDestroysProjectile.value & (1 << collision.gameObject.layer)) > 0)
        {
            // particles

            // damage enemy
            IDamageable iDamageable = collision.gameObject.GetComponent<IDamageable>();
            if (iDamageable != null)
            {
                iDamageable.Damage(projectileDamage, Vector2.up);
            }
            // destroy projectile
            Destroy(gameObject);
        }
    }
    private void SetVelocity()
    {
        rb.velocity = transform.right * projectileSpeed;
    }
    private void SetDestroyTime()
    {
        Destroy(gameObject, destroyTime);
    }
}