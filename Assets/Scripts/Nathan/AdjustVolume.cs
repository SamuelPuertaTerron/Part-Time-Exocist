using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdjustVolume : MonoBehaviour
{
    public void Adjust()
    {
        float value = this.GetComponent<Slider>().value;
        AudioListener.volume = value;
    }
}
