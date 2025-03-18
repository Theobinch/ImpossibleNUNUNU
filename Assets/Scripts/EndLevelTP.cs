using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevelTP : MonoBehaviour
{
    public string sceneName;

    private AudioSource audioSource;
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {
            audioSource.Play();
            Thread.Sleep(2000);
            SceneManager.LoadScene(sceneName);
        }
    }
}