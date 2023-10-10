using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreAway : MonoBehaviour
{
    private TextMeshProUGUI _textMesh;

    private void Start()
    {
        _textMesh = GetComponent<TextMeshProUGUI>();
        _textMesh.text = UIManager.Instance.GameData.GoalsAway.ToString();
    }

    /// <summary>
    /// Update the goals from the away team on the UI
    /// </summary>
    public void UpdateScore()
    {
        _textMesh.text = UIManager.Instance.GameData.GoalsAway.ToString();
    }
}
