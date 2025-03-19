using UnityEngine;

public class GlobalVolumeActivator : MonoBehaviour
{
    public GameObject globalVolume;
    
    void Start()
    {
        //vérifie si Global Volume est assignée
        if (globalVolume != null)
        {
            globalVolume.SetActive(true);
        }
        else
        {
            Debug.LogWarning("Global Volume n'est pas assigné !");
        }
    }
}