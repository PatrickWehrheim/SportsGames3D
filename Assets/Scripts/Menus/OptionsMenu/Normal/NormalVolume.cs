using UnityEngine;
using UnityEngine.UI;

public class NormalVolume : MonoBehaviour
{
    private Slider _slider;
    private NormalVolumeValue _volumeValue;

    private void Awake()
    {
        _slider = GetComponentInChildren<Slider>();
        _volumeValue = GetComponentInChildren<NormalVolumeValue>();
    }

    /// <summary>
    /// Save the current value on the slider
    /// </summary>
    public void OnValueChanged()
    {
        int value = (int)_slider.value;
        OptionsController.Instance.SaveVolume(value);
        _volumeValue.SetValue(value);
        MenuManager.Instance.UpdateMusicVolume(value);
    }

    /// <summary>
    /// Sets the value on the slider
    /// </summary>
    /// <param name="value">Value to set</param>
    public void SetSliderValue(int value)
    {
        _slider.value = value;
        _volumeValue.SetValue(value);
    }
}
