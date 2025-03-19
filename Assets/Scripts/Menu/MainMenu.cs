using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string levelToLoad;
    
    public GameObject OptionWindow;
    
    //permet de charger la premiere scene mis dans l'editeur 
    public void StartGame()
    {
        SceneManager.LoadScene(levelToLoad);        
    }
    
    //ouvre la fenetre options 
    public void Options()
    {
        OptionWindow.SetActive(true);        
    }
    
    //ferme la fenetre option
    public void CloseOptions()
    {
        OptionWindow.SetActive(false);
    }
    
    //ferme la fenetre du jeu 
    public void QuitGame()
    {
        Application.Quit();
    }
}
