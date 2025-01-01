using UnityEngine;

public class CoinItem : MonoBehaviour
{
    [SerializeField] private int coinAmount = 1;
    [SerializeField] private GameObject coinGetPrefab;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            print("Player collided");
            // add coin(s) to player
            collision.gameObject.GetComponent<PlayerCoins>().GetCoin(coinAmount);
            // destroy self
            Destroy(gameObject);
            // create coin get FX and destroy after 1 second
            Destroy(Instantiate(coinGetPrefab, gameObject.transform.position, Quaternion.identity), 1f);
        }
    }
}