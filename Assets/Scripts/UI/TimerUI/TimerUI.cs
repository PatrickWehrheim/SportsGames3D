using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerUI : MonoBehaviour
{
    private Minutes _minutes;
    private Seconds _seconds;

    private int _halfTime = 45;
    private int _fullTime = 90;

    private bool _isHalfTime = false;
    private bool _isFullTime = false;

    private void Awake()
    {
        _minutes = GetComponentInChildren<Minutes>();
        _seconds = GetComponentInChildren<Seconds>();
    }

    private void FixedUpdate()
    {
        //After 60 seconds, increases the minutes and resets the seconds
        //In UI there will be 60 seconds shown for a few milliseconds
        if (_seconds.SecondsTimer == 59.9f)
        {
            _seconds.ResetSeconds();
            _minutes.IncreaseMinutes();
        }
        
        if (!_isHalfTime && _minutes.MinutesTimer == _halfTime)
        {
            _isHalfTime = true;
            GameManager.Instance.OnHalfTime();
        }

        if (!_isFullTime && _minutes.MinutesTimer == _fullTime)
        {
            _isFullTime = true;
            GameManager.Instance.OnFullTime();
        }
    }
}
