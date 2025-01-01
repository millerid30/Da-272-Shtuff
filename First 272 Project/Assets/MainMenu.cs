using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public int sceneBuildIndex;
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
    public void QuitGame()
    {
        Application.Quit();
    }
}