using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    
    public GameObject OptionWindow;
    
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