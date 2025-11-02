using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void OnPlayButtonClicked()
    {
        SceneManager.LoadScene(1);
    }
    public void OnReplayButtonClicked()
    {
        SceneManager.LoadScene(2);
    }

    public void OnQuitButtonClicked()
    {
        Application.Quit();
    }
}
