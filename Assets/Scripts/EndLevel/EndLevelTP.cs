using System.Collections;
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
            StartCoroutine(PlaySoundAndLoadScene());
        }
    }

    private IEnumerator PlaySoundAndLoadScene()
    {
        audioSource.Play();
        yield return new WaitForSeconds(audioSource.clip.length);
        SceneManager.LoadScene(sceneName);
    }
}
