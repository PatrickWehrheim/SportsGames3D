using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FunnyVolume : MonoBehaviour
{
    [SerializeField] private Slider _volumeSlider;
    [SerializeField] private GameObject _volumePlayer;
    [SerializeField] private GameObject _volumeBall;

    private bool _isPointerDown = false;
    private Vector3 _playerStartPoint;
    private Vector3 _ballStartPoint;

    private float _playerSteps = 7f;

    private void Start()
    {
        _playerStartPoint = _volumePlayer.transform.position;
        _ballStartPoint = _volumeBall.transform.position;
    }

    private void FixedUpdate()
    {
        if (_isPointerDown)
        {
            StartCoroutine(IncreaseVolume());
        }
    }

    /// <summary>
    /// Sets the boolean to increase the volume
    /// Starts always with zero
    /// </summary>
    /// <param name="data">Data from BaseEventData</param>
    public void OnDown(BaseEventData data)
    {
        _isPointerDown = true;
        _volumeSlider.value = 0;
        _volumePlayer.transform.position = _playerStartPoint;
        _volumeBall.transform.position = _ballStartPoint;
    }

    /// <summary>
    /// Sets the boolean to increase the volume
    /// </summary>
    /// <param name="data">Data from BaseEventData</param>
    public void OnUp(BaseEventData data)
    {
        StopCoroutine(IncreaseVolume());
        _isPointerDown = false;
        OptionsController.Instance.SaveVolume((int)_volumeSlider.value);
        MenuManager.Instance.UpdateMusicVolume((int)_volumeSlider.value);
    }

    /// <summary>
    /// Increase the volume and move the player with the ball
    /// </summary>
    /// <returns>IEnumerator</returns>
    private IEnumerator IncreaseVolume()
    {
        _volumeSlider.value += 1;
        if (_volumeSlider.value < _volumeSlider.maxValue)
        {
            Vector3 pos = new Vector3(_volumePlayer.transform.position.x + _playerSteps, _volumePlayer.transform.position.y, _volumePlayer.transform.position.z);
            _volumePlayer.transform.position = pos;
            _volumeBall.transform.position = pos + new Vector3(15f, -15f, 0);
        }

        yield return null;
    }

    /// <summary>
    /// Sets the slider with the player and the ball to the current place
    /// </summary>
    /// <param name="volumeValue"></param>
    public void SetValues(int volumeValue)
    {
        _volumeSlider.value = volumeValue;
        Vector3 pos = new Vector3(_volumePlayer.transform.position.x + (_playerSteps * volumeValue), _volumePlayer.transform.position.y, _volumePlayer.transform.position.z);
        _volumePlayer.transform.position = pos;
        _volumeBall.transform.position = pos + new Vector3(15f, -15f, 0);
    }
}
