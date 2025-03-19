using UnityEngine;
using UnityEngine.SceneManagement;

public class EndButton : MonoBehaviour
{
    public void Menu()  
    {
        SceneManager.LoadScene("MainMenu"); 
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
}