using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [Header ("Health")]
    [SerializeField] private float health;
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private bool VanishAtFull;
    public Image healthBar;
    public Image healthBorder;

    [Header("i-Frames")]
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numFlashes;
    private SpriteRenderer spriteRend;
    private bool isInvulnerable;

    private PlatformKnockback knockback;

    void Start()
    {
        health = maxHealth;
        spriteRend = GetComponent<SpriteRenderer>();
        isInvulnerable = false;
        Physics2D.IgnoreLayerCollision(6, 7, false);
        knockback = GetComponent<PlatformKnockback>();
    }
    void Update()
    {
        if (VanishAtFull)
        {
            if (health / maxHealth >= 1)
            {
                healthBar.gameObject.SetActive(false);
                healthBorder.gameObject.SetActive(false);
            }
            else
            {
                healthBar.gameObject.SetActive(true);
                healthBorder.gameObject.SetActive(true);
            }
        }

        if (health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        // TEST damage/heal
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Damage(20, Vector2.zero);
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            Heal(10);
        }
    }
    public void Damage(float damage, Vector2 hitDirection)
    {
        if (!isInvulnerable)
        {
            health -= damage;
            healthBar.fillAmount = health / maxHealth;
            knockback.CallKnockback(hitDirection, Vector2.zero, InputManager.Movement.x);
            if (health > 0)
            {
                StartCoroutine(Invulnerability());
            }
            // damage particles?
        }
    }
    public void Heal(float healingAmount)
    {
        health += healingAmount;
        health = Mathf.Clamp(health, 0, maxHealth);
        healthBar.fillAmount = health / maxHealth;

        // heal particles?
    }
    private IEnumerator Invulnerability()
    {
        isInvulnerable = true;
        Physics2D.IgnoreLayerCollision(6, 7, true);
        for (int i = 0; i < numFlashes; i++)
        {
            spriteRend.color = new Color(1,1,1,0.5f);
            yield return new WaitForSeconds(iFramesDuration/(numFlashes*2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration/(numFlashes*2));
        }
        Physics2D.IgnoreLayerCollision(6, 7, false);
        isInvulnerable = false;
    }
}