using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformKnockback : MonoBehaviour
{
    [SerializeField] private float knockbackTime = 0.2f;
    [SerializeField] private float hitDirectionForce = 10f;
    [SerializeField] private float constForce = 5f;
    [SerializeField] private float inputForce = 7.5f;

    private Rigidbody2D rb;

    private Coroutine knockbackCoroutine;

    public bool IsBeingKnockedBack { get; private set; }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public IEnumerator KnockbackAction(Vector2 hitDirection, Vector2 constantForceDirection, float inputDirection)
    {
        IsBeingKnockedBack = true;

        Vector2 hitForce;
        Vector2 constantForce;
        Vector2 knockbackForce;
        Vector2 combinedForce;

        hitForce = hitDirection * hitDirectionForce;
        constantForce = constantForceDirection * constForce;

        float elapsedTime = 0f;
        while (elapsedTime < knockbackTime)
        {
            // iterate timer
            elapsedTime += Time.fixedDeltaTime;
            // combine hitForce and constantForce
            knockbackForce = hitForce + constantForce;
            // combine knockbackForce with inputForce
            if (inputDirection != 0)
            {
                combinedForce = knockbackForce + new Vector2(inputDirection * inputForce, 0f);
            }
            else
            {
                combinedForce = knockbackForce;
            }
            // apply knockback
            rb.velocity = combinedForce;
            //rb.AddForce(combinedForce, ForceMode2D.Impulse);

            yield return new WaitForFixedUpdate();
        }
        IsBeingKnockedBack = false;
    }
    public void CallKnockback(Vector2 hitDirection, Vector2 constantForceDirection, float inputDirection)
    {
        knockbackCoroutine = StartCoroutine(KnockbackAction(hitDirection, constantForceDirection, inputDirection));
    }
}