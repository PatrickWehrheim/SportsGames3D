using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Minutes : MonoBehaviour
{
    private int _minutes = 0;
    public int MinutesTimer { get { return _minutes; } private set { _minutes = value; } }

    private TextMeshProUGUI _textMeshPro;

    private void Awake()
    {
        _textMeshPro = GetComponent<TextMeshProUGUI>();
    }

    /// <summary>
    /// Increases the minutes and update the UI
    /// </summary>
    public void IncreaseMinutes()
    {
        _minutes++;
        UpdateText(_minutes.ToString("0"));
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
