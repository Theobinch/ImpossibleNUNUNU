using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    
    //permet de restart directement en appuyant sur la barre espace
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RestartGame();
        }
    }
    public void Setup()
    {
        gameObject.SetActive(true);
    }

    //permet de relancer 
    public void RestartButton()
    {
        RestartGame();
    }

    //met la scene 1 apres avoir relance
    private void RestartGame()
    {
        SceneManager.LoadScene("Level01");
    }

    //retourne au menu
    public void ExitButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

    //ferme la fenetre du jeu 
    public void RageQuitButton()
    {
        Application.Quit();

#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}