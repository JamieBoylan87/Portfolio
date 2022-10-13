using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlowMotion : MonoBehaviour
{
    public Slider slider;

    public void SetMaxSlowMo(float health)
    {
        slider.maxValue = health;
        slider.value = health;
    }
    public void SetSlowMo(float health)
    {
        slider.value = health;
    }


}
