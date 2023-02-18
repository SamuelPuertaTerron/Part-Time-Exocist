using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager audioManager;
    void Awake()
    {
        DontDestroyOnLoad(this);
        if(audioManager == null){
            audioManager = this;

        }
        else{
            Destroy(gameObject);
        }
    }
}
