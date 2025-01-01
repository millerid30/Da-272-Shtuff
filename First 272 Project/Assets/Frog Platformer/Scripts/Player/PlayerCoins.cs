using UnityEngine;
using UnityEngine.UI;

public class PlayerCoins : MonoBehaviour
{
    [SerializeField] private int coins;
    [SerializeField] private int maxCoin = 99;
    public Text coinText;
    private void Start()
    {
        coins = 0;
    }
    void Update()
    {
        coinText.text = coins.ToString();
        if (Input.GetKeyDown(KeyCode.C))
        {
            GetCoin(10);
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            LoseCoin(10);
        }
    }
    public void GetCoin(int amount)
    {
        coins += amount;
        coins = Mathf.Clamp(coins, 0, maxCoin);
    }
    public void LoseCoin(int amount)
    {
        coins -= amount;
        coins = Mathf.Clamp(coins, 0, maxCoin);
    }
    public int NumCoins()
    {
        return coins;
    }
}