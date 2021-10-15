using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OxygenBar : MonoBehaviour
{
    private static OxygenBar instance;
    public static OxygenBar Instance { get => instance; }
    public Slider slider;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);

    }
    public void SetMaxOxygen(float oxygen)
    {
        slider.maxValue = oxygen;
        slider.value = oxygen;
    }

    public void SetOxygen(float oxygen)
    {
        slider.value = oxygen;
    }
}
