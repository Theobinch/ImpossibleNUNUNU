using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            RestartGame();
        }
    }
    public void Setup()
    {
        gameObject.SetActive(true);
    }

    public void RestartButton()
    {
        RestartGame();
    }

    private void RestartGame()
    {
        SceneManager.LoadScene("Level01");
    }

    public void ExitButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void RageQuitButton()
    {
        Application.Quit();

#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}