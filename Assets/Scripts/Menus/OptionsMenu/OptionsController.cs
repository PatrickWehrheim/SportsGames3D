using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsController : MonoBehaviour
{
    [SerializeField] private OptionsData _optionsData;
    [SerializeField] private GameObject _funnyScrollView;
    [SerializeField] private GameObject _normalScrollView;

    public static OptionsController Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        LoadScrollView(_optionsData.FunnyOptions);
    }

    /// <summary>
    /// Load the currently saved options view
    /// </summary>
    /// <param name="funnyOptions">true: Load alternate options
    /// false: Load normal options</param>
    private void LoadScrollView(bool funnyOptions)
    {
        if (funnyOptions)
        {
            GameObject funnyScrollView = Instantiate(_funnyScrollView, transform);
            LoadFunnyScrollView(funnyScrollView);
        }
        else
        {
            GameObject normalScrollView = Instantiate(_normalScrollView, transform);
            LoadNormalScrollView(normalScrollView);
        }
    }

    /// <summary>
    /// Change the current options view
    /// </summary>
    /// <param name="activateFunnyOptions">true: Load alternate options
    /// false: Load normal options</param>
    public void OnViewChange(bool activateFunnyOptions)
    {
        _optionsData.FunnyOptions = activateFunnyOptions;
        if (activateFunnyOptions)
        {
            Destroy(GetComponentInChildren<NormalScrollView>().gameObject);
            GameObject funnyScrollView = Instantiate(_funnyScrollView, transform);
            LoadFunnyScrollView(funnyScrollView);
        }
        else
        {
            Destroy(GetComponentInChildren<FunnyScrollView>().gameObject);
            GameObject normalScrollView = Instantiate(_normalScrollView, transform);
            LoadNormalScrollView(normalScrollView);
        }
    }

    /// <summary>
    /// Load all options in the normal view
    /// </summary>
    /// <param name="normalScrollView">GameObject view to load</param>
    private void LoadNormalScrollView(GameObject normalScrollView)
    {
        normalScrollView.GetComponentInChildren<NormalVolume>().SetSliderValue(_optionsData.Volume);
        normalScrollView.GetComponentInChildren<NormalResolution>().SetDropdownValue(_optionsData.Resolution);
        normalScrollView.GetComponentInChildren<NormalLanguage>().SetDropdownValue(_optionsData.Language);
        normalScrollView.GetComponentInChildren<NormalTimeMultiplier>().SetSliderValue(_optionsData.TimeMultiplier);
    }

    /// <summary>
    /// Load all options in the alternate view
    /// </summary>
    /// <param name="funnyScrollView">GameObject view to load</param>
    private void LoadFunnyScrollView(GameObject funnyScrollView)
    {
        funnyScrollView.GetComponentInChildren<FunnyVolume>().SetValues(_optionsData.Volume);
    }

    /// <summary>
    /// Save the current volume value
    /// </summary>
    /// <param name="value">Value to save</param>
    public void SaveVolume(int value)
    {
        _optionsData.Volume = value;
    }

    /// <summary>
    /// Save the current selected resolution
    /// </summary>
    /// <param name="resolution">Number of the option to save</param>
    public void SaveResolution(int resolution)
    {
        _optionsData.Resolution = resolution;
    }

    /// <summary>
    /// Save the current selected language
    /// </summary>
    /// <param name="language">Number of the option to save</param>
    public void SaveLanguage(int language)
    {
        _optionsData.Language = language;
    }

    /// <summary>
    /// Save the current time multiplier value
    /// </summary>
    /// <param name="value">Value to save</param>
    public void SaveTimeMultiplier(int value)
    {
        _optionsData.TimeMultiplier = value;
    }
}
