using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
	public void Setup()
	{
		gameObject.SetActive(true);
	}

	public void RestartButton()
	{
		SceneManager.LoadScene("Test_RangedEnnemy");
	}

	public void ExitButton()
	{
		SceneManager.LoadScene("MainMenu");
	}

	public void RageQuitButton()
	{
		Application.Quit();

		// Si tu es en mode éditeur, pour simuler la fermeture du jeu :
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
	}

}
