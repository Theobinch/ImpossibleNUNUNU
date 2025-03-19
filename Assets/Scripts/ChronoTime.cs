using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ChronoTime : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
	private static float elapsedTime;
    private bool isRunning = true;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    
    //permet de creer un chrono en minute et seconde
    void Update()
    {
        if (isRunning)
        {
            elapsedTime += Time.deltaTime;
            int minutes = Mathf.FloorToInt(elapsedTime / 60);
            int seconds = Mathf.FloorToInt(elapsedTime % 60);
            timerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
        }
    }

    //arrete le chrono et le save 
    public void StopChrono()
    {
        isRunning = false;
		PlayerPrefs.SetFloat("FinalTime", elapsedTime);
		PlayerPrefs.Save();
    }

    //remet le chrono a 0
    public void ResetChrono()
    {
        elapsedTime = 0f;
        isRunning = true;

    }

    //charge la scene de fin de jeu et montre le score
	public void LoadEndScene()
    {
        StopChrono();
        SceneManager.LoadScene("EndGame"); 
    }
}
