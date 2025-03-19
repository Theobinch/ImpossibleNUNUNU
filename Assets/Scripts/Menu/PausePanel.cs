using UnityEngine;
using UnityEngine.SceneManagement;

public class PausePanel : MonoBehaviour
{
    public GameObject pauseMenu;  
    private bool isPaused = false;  

    //si echap appuyer, met pause si le jeu fonctionne sinon remet le jeu en fonctionnement
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();  
            }
            else
            {
                PauseGame();  
            }
        }
    }
    
    //stop le jeu
    public void PauseGame()
    {
        pauseMenu.SetActive(true);  
        Time.timeScale = 0f;  
        isPaused = true;  
    }
    
    //reactive la partie 
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);  
        Time.timeScale = 1f;  
        isPaused = false;  
    }

    //permet de restart et revenir au niveau 1
    public void RestartGame()
    {
        ResumeGame();
        SceneManager.LoadScene("Level01");  
    }
    
    //permet de retourner au menu
    public void Menu()  
    {
        ResumeGame();
        SceneManager.LoadScene("MainMenu"); 
    }
    
    //permet de fermer la fenetre du jeu 
    public void QuitGame()
    {
        Application.Quit();
    }
}