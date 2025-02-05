using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;  // Pour URP si tu utilises ce pipeline
using UnityEngine.SceneManagement;  // Pour charger la scène

public class VignetteController : MonoBehaviour
{
    private Volume volume; 
    private Vignette vignetteEffect;

    void Start()
    {
        // Trouver le Volume global
        volume = GetComponent<Volume>();
        
        // Vérifier si le volume a un override de Vignette
        if (volume.profile.TryGet<Vignette>(out vignetteEffect))
        {
            // Désactiver la vignette au début
            vignetteEffect.active = false;
        }
    }

    // Méthode pour activer la vignette quand le niveau 02 est lancé
    public void StartLevel02Vignette()
    {
        // Activer la vignette au début du niveau 02
        if (vignetteEffect != null)
        {
            vignetteEffect.active = true;
            vignetteEffect.intensity.Override(0.5f);  // Ajuste l'intensité de la vignette
        }
    }
}