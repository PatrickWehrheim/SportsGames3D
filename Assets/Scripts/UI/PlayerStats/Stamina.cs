using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stamina : MonoBehaviour
{
    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    /// <summary>
    /// Update the stamina for the current player on the UI 
    /// </summary>
    /// <param name="stamina">Stamina value from the player</param>
    public void SetStamina(int stamina)
    {
        _slider.value = stamina;
    }
}
