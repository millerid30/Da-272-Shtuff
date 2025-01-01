using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDamage : MonoBehaviour
{
    [SerializeField] private float fallDamage;
    private PlayerHealth playerHealth;
    private SafeGroundSaver safeGroundSaver;

    private void Start()
    {
        safeGroundSaver = GameObject.FindGameObjectWithTag("Player").GetComponent<SafeGroundSaver>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            safeGroundSaver.WarpPlayerToSafeGround();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerHealth = collision.gameObject.GetComponent<PlayerHealth>();

            // take damage
            playerHealth.Damage(fallDamage,Vector2.down);

            // warp player to SafeGroundLocation
            safeGroundSaver.WarpPlayerToSafeGround();
        }
    }
}