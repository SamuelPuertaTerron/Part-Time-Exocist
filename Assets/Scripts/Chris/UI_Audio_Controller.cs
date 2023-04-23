using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PartTimeExocist
{
    public class UI_Audio_Controller : MonoBehaviour
    {
        public static UI_Audio_Controller instance;

        private AudioSource audioSource;

        //  private AudioClip[] buttonsSounds;

        public int randomButtonSound;

        [SerializeField] AudioClip[] buttonsSounds;

        // Start is called before the first frame update
        void Start()
        {
            instance = this;
            audioSource = GetComponent<AudioSource>();
            // buttonsSounds = Resources.LoadAll<AudioClip>("UI_Sounds");
        }

        public void PlayButtonSound()
        {
            randomButtonSound = Random.Range(0, buttonsSounds.Length);
            audioSource.PlayOneShot(buttonsSounds[randomButtonSound]);
        }
    }
}

