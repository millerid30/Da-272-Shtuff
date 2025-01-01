using UnityEngine;
using UnityEngine.UI;

public class SignRead : MonoBehaviour
{
    [SerializeField] private Image message;
    void Start()
    {
        message.gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            message.gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            message.gameObject.SetActive(false);
        }
    }
}