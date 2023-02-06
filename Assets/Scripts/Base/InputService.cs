using System;
using Toolkit;
using UnityEngine;

namespace Base
{
    public class InputService : MonoBehaviour
    {
        [SerializeField] private float _deadZone = 0.3f;
        [SerializeField] private Joystick _joystick;
        [SerializeField] private ReactiveTransform _handle;
        private bool _isBlockHorizontal;
        
        public event Action OnBlock;
        public event Action OnUnblock;
        #region Enable / Disable

        private void OnEnable()
        {
            _handle.OnDisableEvent += UnblockHorizontal;
        }

        private void OnDisable()
        {
            _handle.OnDisableEvent -= UnblockHorizontal;
        }

        #endregion
        public bool IsHorizontal()
        {
            if (_isBlockHorizontal) return false;
            return GetVertical() > -_deadZone && GetVertical() < _deadZone;
        }

        public float GetHorizontal() => 
            _joystick.Horizontal + Input.GetAxis("Horizontal");

        public float GetVertical() => 
            _joystick.Vertical + Input.GetAxis("Vertical");

        public void BlockHorizontal()
        {
            _isBlockHorizontal = true;
            OnBlock?.Invoke();
        }

        private void UnblockHorizontal()
        {
            _isBlockHorizontal = false;
            OnUnblock?.Invoke();
        }
    }
}