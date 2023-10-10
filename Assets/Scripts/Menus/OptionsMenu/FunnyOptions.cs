using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FunnyOptions : MonoBehaviour
{
    private Toggle _toggle;

    private void Awake()
    {
        _toggle = GetComponentInChildren<Toggle>();
    }

    /// <summary>
    /// Change the options view
    /// </summary>
    /// <param name="isOn">true: Change to alternate options
    /// false: Change to normal options</param>
    public void ChangeOptionsView(bool isOn)
    {
        OptionsController.Instance.OnViewChange(isOn);
    }

    /// <summary>
    /// Sets the toggle
    /// </summary>
    /// <param name="isOn">Sets toggle on true or false</param>
    public void SetToggle(bool isOn)
    {
        _toggle.isOn = isOn;
    }
}
