using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerKeys : MonoBehaviour
{
    [SerializeField] private int keys;
    [SerializeField] private int maxKey;
    public Text keyText;
    public GameObject keyUI;
    // Start is called before the first frame update
    void Start()
    {
        keys = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (keys == 0)
        {
            keyText.gameObject.SetActive(false);
        }
        else
        {
            keyText.gameObject.SetActive(true);
        }

        keyText.text = keys.ToString();



        if (Input.GetKeyDown(KeyCode.K))
        {
            GetKey();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            UseKey();
        }
    }
    public void GetKey()
    {
        keys++;
        keys = Mathf.Clamp(keys, 0, maxKey);
    }
    public void UseKey()
    {
        keys--;
        keys = Mathf.Clamp(keys, 0, maxKey);
    }
    public int NumKeys()
    {
        return keys;
    }
}