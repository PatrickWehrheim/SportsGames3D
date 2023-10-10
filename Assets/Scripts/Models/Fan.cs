using UnityEngine;

namespace Assets.Scripts.Models
{
    public class Fan : MonoBehaviour
    {
        private float _pingPongStartY;
        private Vector3 _pingPongEnd;
        private float _pingPongSpeed;
        private float _pingPongSpeedMax = 1.1f;
        private float _pingPongSpeedMin = .5f;
        private float _pingPongLength = .3f;

        private void Awake()
        {
            _pingPongStartY = transform.position.y;
            _pingPongSpeed = Random.Range(_pingPongSpeedMin, _pingPongSpeedMax);
        }
        private void Update()
        {
            _pingPongEnd = new Vector3(transform.position.x, _pingPongStartY, transform.position.z);

            _pingPongEnd.y = _pingPongEnd.y + Mathf.PingPong(_pingPongSpeed * Time.time, _pingPongLength);
            transform.position = _pingPongEnd;
        }
    }
}
