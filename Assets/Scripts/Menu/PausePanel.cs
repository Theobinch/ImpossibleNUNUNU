using UnityEngine;
using UnityEngine.SceneManagement;

public class PausePanel : MonoBehaviour
{
    public GameObject pauseMenu;  
    private bool isPaused = false;  

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
    
    public void PauseGame()
    {
        pauseMenu.SetActive(true);  
        Time.timeScale = 0f;  
        isPaused = true;  
    }
    
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);  
        Time.timeScale = 1f;  
        isPaused = false;  
    }

    public void RestartGame()
    {
        ResumeGame();
        SceneManager.LoadScene("Level01");  
    }
    
    public void Menu()  
    {
        ResumeGame();
        SceneManager.LoadScene("MainMenu"); 
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
}