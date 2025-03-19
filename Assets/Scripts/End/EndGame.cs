using UnityEngine;
using TMPro;

public class EndGame : MonoBehaviour
{
    public TMP_Text timeText;

    void Start()
    {
        float finalTime = PlayerPrefs.GetFloat("FinalTime", 0f);
        int minutes = Mathf.FloorToInt(finalTime / 60);
        int seconds = Mathf.FloorToInt(finalTime % 60);
        timeText.text = "YOUR TIME | " + string.Format("{0:00} : {1:00}", minutes, seconds);
    }
}