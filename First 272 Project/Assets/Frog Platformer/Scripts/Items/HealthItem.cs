using UnityEngine;
public class HealthItem : MonoBehaviour
{
    [SerializeField] private int healthAmount = 50;
    [SerializeField] private GameObject healGetPrefab;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // add health to player
            collision.gameObject.GetComponent<PlayerHealth>().Heal(healthAmount);
            // destroy self
            Destroy(gameObject);
            // create health item FX and destroy after 0.5 seconds
            Destroy(Instantiate(healGetPrefab, gameObject.transform.position, Quaternion.identity), 0.5f);
        }
    }
}