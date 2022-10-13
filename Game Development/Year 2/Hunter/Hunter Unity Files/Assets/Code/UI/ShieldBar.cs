using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldBar : MonoBehaviour
{
    public Slider slider;
    private bool ShieldReg = false;


    public void SetMaxShield(float health)
    {
        slider.maxValue = health;
        slider.value = health;
    }
    public void SetShield(float health)
    {
        slider.value = health;
    }


}
