using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreHome : MonoBehaviour
{
    private TextMeshProUGUI _textMesh;

    private void Start()
    {
        _textMesh = GetComponent<TextMeshProUGUI>();
        _textMesh.text = UIManager.Instance.GameData.GoalsHome.ToString();
    }

    /// <summary>
    /// Update the goals from the home team on the UI
    /// </summary>
    public void UpdateScore()
    {
        _textMesh.text = UIManager.Instance.GameData.GoalsHome.ToString();
    }
}
