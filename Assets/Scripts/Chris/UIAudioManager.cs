using UnityEngine;

namespace PartTimeExocist
{
    public class UIAudioManager : Extensions.Singleton<UIAudioManager>
    {
        private AudioSource audioSource;

        //  private AudioClip[] buttonsSounds;

        public int randomButtonSound;

        [SerializeField] AudioClip[] buttonsSounds;

        // Start is called before the first frame update
        void Start()
        {
            audioSource = GetComponent<AudioSource>();
        }

        public void PlayButtonSound()
        {
            randomButtonSound = Random.Range(0, buttonsSounds.Length);
            audioSource.PlayOneShot(buttonsSounds[randomButtonSound]);
        }
    }
}

