using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Seconds : MonoBehaviour
{
    [SerializeField] private OptionsData _optionsData;

    private float _seconds = 0;

    private float _maxSeconds = 59.9f;
    [HideInInspector] public float SecondsTimer { get { return _seconds; } private set { _seconds = value; } }

    public int SecondsMultiplier; //Increase the gametime by this value

    private TextMeshProUGUI _textMeshPro;

    private void Awake()
    {
        SecondsMultiplier = _optionsData.TimeMultiplier;
        _textMeshPro = GetComponent<TextMeshProUGUI>();
    }

    private void FixedUpdate()
    {
        if (!GameManager.Instance.IsGamePaused)
        {
            _seconds += Time.deltaTime * SecondsMultiplier;

            if (_seconds > _maxSeconds)
            {
                _seconds = _maxSeconds;
            }

            //Updates the seconds on the UI if a full second is reached 
            if (_seconds % 1 >= 0)
            {
                UpdateText(_seconds.ToString("00"));
            }
        }
    }

    /// <summary>
    /// Rests the seconds
    /// </summary>
    public void ResetSeconds()
    {
        _seconds = 0;
    }

    /// <summary>
    /// Update the text to the given string
    /// </summary>
    /// <param name="text">The text to update in UI</param>
    private void UpdateText(string text)
    {
        _textMeshPro.text = text;
    }
}
