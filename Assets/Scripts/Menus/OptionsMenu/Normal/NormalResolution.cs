using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NormalResolution : MonoBehaviour
{
    private TMP_Dropdown _dropdown;

    private void Awake()
    {
        _dropdown = GetComponentInChildren<TMP_Dropdown>();
    }

    /// <summary>
    /// Save the selected option
    /// </summary>
    public void OnValueChanged()
    {
        OptionsController.Instance.SaveResolution(_dropdown.value);
    }

    /// <summary>
    /// Sets the current option
    /// </summary>
    /// <param name="value">Value to set</param>
    public void SetDropdownValue(int value)
    {
        _dropdown.value = value;
    }
}
