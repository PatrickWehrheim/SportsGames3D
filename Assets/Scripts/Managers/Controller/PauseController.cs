using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    private void Awake()
    {
        if (GameManager.Instance.IsGameEnded)
        {
            GetComponentInChildren<ResumeButton>().gameObject.SetActive(false);
        }       
    }
}
