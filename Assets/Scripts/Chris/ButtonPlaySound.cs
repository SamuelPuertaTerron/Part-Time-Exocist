using UnityEngine;
using UnityEngine.UI;

namespace PartTimeExocist
{
    public class ButtonPlaySound : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            gameObject.GetComponent<Button>().onClick.AddListener(ButtonPlay);
        }

        private void ButtonPlay()
        {
           UIAudioManager.Instance.PlayButtonSound();
        }
    }
}

