using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunnyScrollView : MonoBehaviour
{
    /// <summary>
    /// Show this view
    /// </summary>
    public void EnableView()
    {
        gameObject.SetActive(true);
        GetComponentInChildren<FunnyOptions>().SetToggle(true);
    }

    /// <summary>
    /// Hide this view
    /// </summary>
    public void DisableView()
    {
        gameObject.SetActive(false);
    }
}
