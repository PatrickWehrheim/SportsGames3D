using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NormalTimeMultiplier : MonoBehaviour
{
    private Slider _slider;
    private NormalTimeMultiplierValue _timeMultiplierValue;

    private void Awake()
    {
        _slider = GetComponentInChildren<Slider>();
        _timeMultiplierValue = GetComponentInChildren<NormalTimeMultiplierValue>();
    }

    /// <summary>
    /// Save the current value on the slider
    /// </summary>
    public void OnValueChanged()
    {
        OptionsController.Instance.SaveTimeMultiplier((int)_slider.value);
        _timeMultiplierValue.SetValue((int)_slider.value);
    }

    /// <summary>
    /// Sets the value on the slider
    /// </summary>
    /// <param name="value">Value to set</param>
    public void SetSliderValue(int value)
    {
        _slider.value = value;
        _timeMultiplierValue.SetValue(value);
    }
}
