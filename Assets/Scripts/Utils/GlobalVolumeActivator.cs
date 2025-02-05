using UnityEngine;

public class GlobalVolumeActivator : MonoBehaviour
{
    // Référence au Global Volume
    public GameObject globalVolume;

    // Cette fonction est appelée quand le niveau commence
    void Start()
    {
        // Vérifie si la référence au Global Volume est assignée
        if (globalVolume != null)
        {
            // Active le GlobalVolume
            globalVolume.SetActive(true);
        }
        else
        {
            Debug.LogWarning("Global Volume n'est pas assigné !");
        }
    }
}