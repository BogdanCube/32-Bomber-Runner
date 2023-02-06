using System;
using Core.Player;
using UnityEngine;
using UnityEngine.Events;

namespace Base.Tutorial
{
    public class TriggerEvent : MonoBehaviour
    {
        public UnityEvent OnTrigger;

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<Player>())
            {
                OnTrigger?.Invoke();
            }
        }
    }
}