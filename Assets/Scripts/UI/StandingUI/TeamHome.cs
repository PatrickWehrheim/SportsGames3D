using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TeamHome : MonoBehaviour
{
    private TextMeshProUGUI _textMesh;

    private void Start()
    {
        _textMesh = GetComponent<TextMeshProUGUI>();
        _textMesh.text = UIManager.Instance.GameData.HomeTeamName.ToString();
    }

    /// <summary>
    /// Sets the home team name on the UI
    /// </summary>
    public void SetName()
    {
        _textMesh.text = UIManager.Instance.GameData.HomeTeamName.ToString();
    }
}
