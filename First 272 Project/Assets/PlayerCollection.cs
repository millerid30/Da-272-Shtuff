using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollection : MonoBehaviour
{

    // Keys
    public int numKeys = 0;

    // Ammo
    public int numAmmo = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // check type of collectible did we run into?
        if (collision.gameObject.CompareTag("Key"))
        {
            // adding to numkeys by
            numKeys = numKeys + 1;
            // destroy that key object
            Destroy(collision.gameObject);
        }
    }
}
