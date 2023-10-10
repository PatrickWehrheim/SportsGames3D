using TMPro;
using UnityEngine;

public class NormalTimeMultiplierValue : MonoBehaviour
{
    private TextMeshProUGUI _text;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    /// <summary>
    /// Set the current value as text
    /// </summary>
    /// <param name="value">Value to set</param>
    public void SetValue(int value)
    {
        _text.text = value.ToString();
    }
}
