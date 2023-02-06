using System;
using Toolkit.Extensions;
using UnityEngine;

namespace Base.Screen
{
    public class UIScreen : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private bool _isDeactivate;
 
        private readonly int _showNameId = Animator.StringToHash("Show");
        private readonly int _hideNameId = Animator.StringToHash("Hide");
        private readonly int _noNameId = Animator.StringToHash("No");
        public async void Show()
        {
            transform.Activate();
            ShowHook();
            await _animator.SetAsyncTrigger(_showNameId);

        }
        protected virtual void ShowHook() {}
        public async void Hide(Action callback = null)
        {
            HideHook();
            await _animator.SetAsyncTrigger(_hideNameId);
            
            callback?.Invoke();
            if (_isDeactivate)
            {
                transform.Deactivate();
            }
        }
        protected virtual void HideHook() {}

        public void SetNo()
        {
            transform.Activate();
            _animator.SetTrigger(_noNameId);
        }
    }
}