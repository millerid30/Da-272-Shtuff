using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItem : MonoBehaviour
{
    [SerializeField] private GameObject keyGetPrefab;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // add key to player
            collision.gameObject.GetComponent<PlayerKeys>().GetKey();
            // destroy self
            Destroy(gameObject);
            // create key get FX and destroy after 0.5 seconds
            Destroy(Instantiate(keyGetPrefab, gameObject.transform.position, Quaternion.identity), 0.5f);
        }
    }
}