using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderTest : MonoBehaviour
{

    public Slider sliderInstance;
    public PlayerMove playerScript;

    void Start()
    {
        sliderInstance.minValue = 0;
        sliderInstance.maxValue = 100;
        sliderInstance.wholeNumbers = true;
        sliderInstance.value = 11;
    }

    void Update()
    {
        playerScript.pushPower = sliderInstance.value;
    }

    public void OnValueChanged(float value)
    {
        Debug.Log("New Value" + value);
    }
}
