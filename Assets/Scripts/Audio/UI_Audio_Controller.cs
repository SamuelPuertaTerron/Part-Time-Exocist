using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Audio_Controller : MonoBehaviour
{
    public static UI_Audio_Controller instance;

    private AudioSource audioSource;

    public AudioClip[] buttonsSounds;

    private int randomButtonSound;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        audioSource = GetComponent<AudioSource>();
        //buttonsSounds = Resources.LoadAll<AudioClip>("UI_Sounds");
    }

    public void PlayButtonSound()
    {
        randomButtonSound = Random.Range(0, 3);
        audioSource.PlayOneShot(buttonsSounds[randomButtonSound]);
    }
}