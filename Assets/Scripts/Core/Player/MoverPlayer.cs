using System;
using Base;
using UnityEngine;
using UnityEngine.AI;

namespace Core.Player
{
    public class MoverPlayer : MonoBehaviour
    {
        [SerializeField] private float _horizontalSpeed = 2;
        [SerializeField] private float _speed = 5;
        [SerializeField] private NavMeshAgent _agent;
        private bool _isStop;
        public void Move(float horizontal)
        {
            if(_isStop) return;
            
            var moveVector = new Vector3(horizontal * _horizontalSpeed, 0, 1);
            _agent.Move(moveVector * (_speed * Time.deltaTime));
        }

        public void Stop()
        {
            _isStop = true;
        }
    }
}