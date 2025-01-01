using System.Collections;
using UnityEngine;
public class Enemy : MonoBehaviour, IDamageable
{
    [Header("Health")]
    [SerializeField] private float damageDealt = 20;
    [SerializeField] private float maxhealth = 20;
    [SerializeField] private float damageFlashDuration = 0.2f;
    [Header("Coins")]
    [SerializeField] private int heldCoins = 1;
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private GameObject gemPrefab;
    [Header("Movement")]
    [SerializeField] private GameObject pointA;
    [SerializeField] private GameObject pointB;
    [SerializeField] private float speed;
    private Transform currentPoint;
    private float health = 0;

    private SpriteRenderer spriteRend;
    private Rigidbody2D rb;

    private void Start()
    {
        health = maxhealth;
        spriteRend = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        currentPoint = pointB.transform;
    }
    private void FixedUpdate()
    {
        Vector2 point = currentPoint.position - transform.position;
        if (currentPoint == pointB.transform)
        {
            rb.velocity = new Vector2(speed, 0);
        }
        else
        {
            rb.velocity = new Vector2(-speed, 0);
        }

        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointB.transform)
        {
            transform.Rotate(0f, 180f, 0f);
            currentPoint = pointA.transform;
        }
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointA.transform)
        {
            transform.Rotate(0f, 180f, 0f);
            currentPoint = pointB.transform;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // do damage to player
            collision.gameObject.GetComponent<PlayerHealth>().Damage(damageDealt, (collision.gameObject.transform.position - this.transform.position));

            // take coins
            //Steal(stealAmount);
        }
    }
    public void Damage(float damage, Vector2 hitDirection)
    {
        health -= damage;
        if (health <= 0)
        {
            DropCoins();
            Destroy(gameObject);
        }
        else
        {
            StartCoroutine(DamageFlash());
        }
    }
    public void DropCoins()
    {
        while (heldCoins > 0)
        {
            while (heldCoins % 5 != 0)
            {
                // coin throw
                var coin = Instantiate(coinPrefab, gameObject.transform.position, Quaternion.identity);
                coin.GetComponent<Rigidbody2D>().AddForce(new Vector2(UnityEngine.Random.Range(-0.2f, 0.2f), UnityEngine.Random.Range(0.5f, 1)) * 300f);
                heldCoins--;
            }
            if (heldCoins != 0)
            {
                // gem throw
                var gem = Instantiate(gemPrefab, gameObject.transform.position, Quaternion.identity);
                gem.GetComponent<Rigidbody2D>().AddForce(new Vector2(UnityEngine.Random.Range(-0.2f, 0.2f), UnityEngine.Random.Range(0.5f, 1)) * 300f);
                heldCoins -= 5;
            }
        }
    }
    private IEnumerator DamageFlash()
    {
        spriteRend.color = new Color(1, 1, 1, 0.5f);
        yield return new WaitForSeconds(damageFlashDuration/2);
        spriteRend.color = Color.white;
        yield return new WaitForSeconds(damageFlashDuration/2);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pointA.transform.position, 0.5f);
        Gizmos.DrawWireSphere(pointB.transform.position, 0.5f);
    }
}