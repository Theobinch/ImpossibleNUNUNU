using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string levelToLoad;
    
    public GameObject OptionWindow;
    
    public void StartGame()
    {
        SceneManager.LoadScene(levelToLoad);        
    }
    
    public void Options()
    {
        OptionWindow.SetActive(true);        
    }

    public void CloseOptions()
    {
        OptionWindow.SetActive(false);
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
}
