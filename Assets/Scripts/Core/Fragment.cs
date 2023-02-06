using System;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

namespace Core
{
    public class Fragment : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;

        public void Force(Vector3 direction)
        {
            _rigidbody.AddForce(direction, ForceMode.Impulse);
        }
    }
}