using System;
using Base;
using Core.Aim;
using NaughtyAttributes;
using UnityEngine;

namespace Core.Player
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private InputService _input;
        [SerializeField] private MoverPlayer _mover;
        [SerializeField] private AnimationPlayer _animation;
        [SerializeField] private MoverAim _aim;
        [SerializeField] private BombPlayer _bomb;
        private void Update()
        {
            if (_bomb.IsExplosion) return;

            if (IsBombing())
            {
                Bombing();
            }
            else
            {
                Running();
            }
        }
        
        private void Running()
        {
            _animation.IsRunning = true;
            _mover.Move(_input.GetHorizontal());
        }
        private void Bombing()
        {
            _input.BlockHorizontal();
            _animation.IsRunning = false;
            _aim.Move(_input.GetVertical());
        }
        private bool IsBombing() => 
            _input.IsHorizontal() == false && _bomb.HasBomb;
    }
}