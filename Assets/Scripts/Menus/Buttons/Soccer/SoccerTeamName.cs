using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SoccerTeamName : MonoBehaviour
{
    private TextMeshProUGUI _textMeshPro;

    private void Awake()
    {
        _textMeshPro = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateText(string name)
    {
        _textMeshPro.text = name;
    }
}
