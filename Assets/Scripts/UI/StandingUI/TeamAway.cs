using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TeamAway : MonoBehaviour
{
    private TextMeshProUGUI _textMesh;

    private void Start()
    {
        _textMesh = GetComponent<TextMeshProUGUI>();
        _textMesh.text = UIManager.Instance.GameData.AwayTeamName.ToString();
    }

    /// <summary>
    /// Sets the away team name on the UI
    /// </summary>
    public void SetName()
    {
        _textMesh.text = UIManager.Instance.GameData.AwayTeamName.ToString();
    }
}
