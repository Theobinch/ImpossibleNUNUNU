using UnityEngine;
using UnityEngine.SceneManagement;

public class EndButton : MonoBehaviour
{
    
    //Retour au menu du jeu
    public void Menu()  
    {
        SceneManager.LoadScene("MainMenu"); 
    }
    
    //Ferme la fenetre du jeu
    public void QuitGame()
    {
        Application.Quit();
    }
}