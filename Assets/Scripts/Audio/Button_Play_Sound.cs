using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_Play_Sound : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(ButtonPlay);
    }

    private void ButtonPlay()
    {
        UI_Audio_Controller.instance.PlayButtonSound();
    }
}