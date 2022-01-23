using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SpiritBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxSpirit(int maxSpirit)
    {
        slider.maxValue = maxSpirit;
        slider.value = maxSpirit;
    }

    public void SetCurrentSpirit(int currentSpirit)
    {
        slider.value = currentSpirit;
    }
}