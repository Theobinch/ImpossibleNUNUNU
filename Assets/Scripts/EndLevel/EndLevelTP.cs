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

    //lorsque l'objet est touche par le joeueur, lance un son puis charge la scene suivante 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {
            StartCoroutine(PlaySoundAndLoadScene());
        }
    }

    //joue un son puis charge la scene a la fin du son 
    private IEnumerator PlaySoundAndLoadScene()
    {
        audioSource.Play();
        yield return new WaitForSeconds(audioSource.clip.length);
        SceneManager.LoadScene(sceneName);
    }
}
