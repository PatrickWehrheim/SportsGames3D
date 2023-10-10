using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootPower : MonoBehaviour
{
    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    /// <summary>
    /// Update the shootpower for the current player on the UI 
    /// </summary>
    /// <param name="power">Shootpower given by input</param>
    public void SetPower(int power)
    {
        if (_slider.maxValue > power)
        {
            _slider.value += power;
        }
        else
        {
            _slider.value = _slider.maxValue;
        }
    }
}
