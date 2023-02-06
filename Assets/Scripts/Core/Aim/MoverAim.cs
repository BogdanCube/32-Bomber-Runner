using UnityEngine;

namespace Core.Aim
{
    public class MoverAim : MonoBehaviour
    {
        [SerializeField] private float _speed;
        
        public void Move(float vertical)
        {
            var currentSpeed = vertical > 0 ? _speed : -_speed;
            var vector = transform.forward * (currentSpeed * Time.deltaTime);
            transform.Translate(vector);
        }
    }
}