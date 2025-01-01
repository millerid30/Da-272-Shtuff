using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelMove : MonoBehaviour
{
    public int sceneBuildIndex;

    private void OnTriggerEnter2D(Collider2D other)
    {
        print("Trigger Entered");
        if (other.tag == "Player")
        {
            print($"Switching Scene to {sceneBuildIndex}");
            LoadScene(sceneBuildIndex);
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.End))
        {
            SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
        }
    }
    public void LoadScene(int sceneBuildIndex)
    {
        SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
    }
}