using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChronoTime : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
	private static float elapsedTime;
    private bool isRunning = true;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }


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

    public void StopChrono()
    {
        isRunning = false;
    }

    public void ResetChrono()
    {
        elapsedTime = 0f;
        isRunning = true;

    }
}
