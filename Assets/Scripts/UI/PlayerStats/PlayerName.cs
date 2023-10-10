using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerName : MonoBehaviour
{
    private TextMeshProUGUI _textMeshPro;

    private void Awake()
    {
        _textMeshPro = GetComponent<TextMeshProUGUI>();
    }

    /// <summary>
    /// Updates the current playername on the UI
    /// </summary>
    /// <param name="name">Playername</param>
    public void UpdateName(string name)
    {
        _textMeshPro.text = name;
    }
}
