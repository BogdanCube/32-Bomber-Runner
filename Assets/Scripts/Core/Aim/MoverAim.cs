using UnityEngine;

namespace Core.Aim
{
    public class MoverAim : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _limit = 7;
        private Vector3 _startPosition;

        public void SetStartPosition(Vector3 startPosition)
        {
            _startPosition = startPosition;
            transform.position = startPosition;
        }
        public void Move(float vertical)
        {
            ClampPosition();

            var currentSpeed = vertical > 0 ? _speed : -_speed;
            var vector = transform.forward * (currentSpeed * Time.deltaTime);
            transform.Translate(vector);
        }

        private void ClampPosition()
        {
            var start = _startPosition.z;
            var max = _limit + _startPosition.z;
            var temp = transform.position;
            temp.z = Mathf.Clamp(temp.z, start, max);
            transform.position = temp;
        }
    }
}