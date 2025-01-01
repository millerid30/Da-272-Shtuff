using System;
using System.Collections;
using UnityEngine;

public class TreasureChest : MonoBehaviour
{
    [SerializeField] private int heldCoins = 0;
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private GameObject gemPrefab;
    private float launchForce = 300f;

    private Animator anim;
    private bool open;
    void Start()
    {
        anim = GetComponent<Animator>();
        open = false;
    }
    void Update()
    {
        // dispense contents
        if (open)
        {
            Dispense();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.gameObject.GetComponent<PlayerKeys>().NumKeys() > 0 && !open)
            {
                // open chest
                anim.SetBool("IsOpen", true);
                open = true;
                collision.GetComponent<PlayerKeys>().UseKey();
            }
            if (collision.gameObject.GetComponent <PlayerKeys>().NumKeys() <=0 && !open)
            {
                // shake chest
                anim.SetBool("IsTouching", true);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            anim.SetBool("IsTouching", false);
        }
    }
    private void Dispense()
    {
        while (heldCoins > 0)
        {
            while (heldCoins % 5 != 0)
            {
                // coin throw
                var coin = Instantiate(coinPrefab, gameObject.transform.position, Quaternion.identity);
                coin.GetComponent<Rigidbody2D>().AddForce(new Vector2(UnityEngine.Random.Range(-0.2f, 0.2f), UnityEngine.Random.Range(0.5f, 1)) * launchForce);
                heldCoins--;
            }
            // gem throw
            var gem = Instantiate(gemPrefab, gameObject.transform.position, Quaternion.identity);
            gem.GetComponent<Rigidbody2D>().AddForce(new Vector2(UnityEngine.Random.Range(-0.2f, 0.2f), UnityEngine.Random.Range(0.5f, 1)) * launchForce);
            heldCoins -= 5;
        }
    }
}