using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour
{
    public static LevelTransition instance;
    public Animator animator;
    public GameObject fadeImageObject;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        FindFadeImage();
        StartCoroutine(FadeIn());
    }

    public void LoadSceneWithTransition(string sceneName)
    {
        StartCoroutine(PlayTransition(sceneName));
    }

    private IEnumerator PlayTransition(string sceneName)
    {
         if (animator == null) FindFadeImage();
        fadeImageObject.SetActive(true);
        animator.SetTrigger("FadeOutTrigger");

        yield return new WaitForSeconds(1f); 

        SceneManager.LoadScene(sceneName);
        yield return new WaitForSeconds(0.2f); 

        StartCoroutine(FadeIn());
    }

    private IEnumerator FadeIn()
    {
        animator.SetTrigger("FadeInTrigger");
        yield return new WaitForSeconds(1f);
        fadeImageObject.SetActive(false); 
    }

    private void FindFadeImage()
    {
        fadeImageObject = GameObject.Find("FadeImage");
        if (fadeImageObject != null)
        {
            animator = fadeImageObject.GetComponent<Animator>();
            fadeImageObject.SetActive(true);
        }
        else
        {
            Debug.LogError("FadeImage introuvable dans la scène !");
        }
    }
}
