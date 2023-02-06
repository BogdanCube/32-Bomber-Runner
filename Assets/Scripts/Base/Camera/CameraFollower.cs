using System;
using UnityEngine;

namespace Base.Camera
{
    public class CameraFollower : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private float _speed;
        [SerializeField] private Vector3 _offset;
        
        private void LateUpdate()
        {
            transform.position = Vector3.Lerp(transform.position, _target.position + _offset, _speed * Time.deltaTime);
        }
    }
}