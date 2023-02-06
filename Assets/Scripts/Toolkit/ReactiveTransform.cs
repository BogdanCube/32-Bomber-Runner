using System;
using UnityEngine;

namespace Toolkit
{
    public class ReactiveTransform : MonoBehaviour
    {
        public event Action OnEnableEvent;
        public event Action OnDisableEvent;

        private void OnEnable()
        {
            OnEnableEvent?.Invoke();
        }

        private void OnDisable()
        {
            OnDisableEvent?.Invoke();
        }
    }
}