using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TopDownPlayerHealth : MonoBehaviour
{
    public Image healthBar;
    public Image healthBorder;
    [SerializeField] private float health;
    [SerializeField] private float maxHealth = 100f;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
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

        if (health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        // damage/heal test
        if (Input.GetKeyDown(KeyCode.P))
        {
            TopDownDamage(20);
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            TopDownHeal(10);
        }
    }

    public void TopDownDamage(float damage)
    {
        health -= damage;
        healthBar.fillAmount = health / maxHealth;
    }

    public void TopDownHeal(float healingAmount)
    {
        health += healingAmount;
        health = Mathf.Clamp(health, 0, maxHealth);
        healthBar.fillAmount = health / maxHealth;
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Enemy"))
    //    {
    //        TakeDamage(0);
    //    }
    //}
}