using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalScrollView : MonoBehaviour
{
    /// <summary>
    /// Show this view
    /// </summary>
    public void EnableView()
    {
        gameObject.SetActive(true);
        GetComponentInChildren<FunnyOptions>().SetToggle(false);
    }

    /// <summary>
    /// Hide this view
    /// </summary>
    public void DisableView()
    {
        gameObject.SetActive(false);
    }
}
