using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevelTP : MonoBehaviour
{
    public string sceneName;

    private AudioSource audioSource;
    [SerializeField] private AudioClip checkpointSound;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = checkpointSound;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {
            audioSource.PlayOneShot(checkpointSound);
            Thread.Sleep(2000);
            SceneManager.LoadScene(sceneName);
        }
    }
}