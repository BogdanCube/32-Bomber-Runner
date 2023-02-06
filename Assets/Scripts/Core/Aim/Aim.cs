using System;
using Base;
using Core.Player;
using Toolkit.Extensions;
using UnityEngine;
using UnityEngine.Serialization;

namespace Core.Aim
{
    public class Aim : MonoBehaviour
    {
        [SerializeField] private InputService _input;
        [SerializeField] private DetectorWall _detector;
        [SerializeField] private BombPlayer _player;
        [SerializeField] private Transform _startPoint;
        [SerializeField] private Transform _model;
        private bool _isActive = false;
        #region Enable / Disable

        private void OnEnable()
        {
            _input.OnBlock += TurnOn;
            _input.OnUnblock += ExplosionWall;
        }
        private void OnDisable()
        {
            _input.OnBlock -= TurnOn;
            _input.OnUnblock -= ExplosionWall;
        }

        #endregion

        private void Start()
        {
            _model.Deactivate();
        }

        private void TurnOn()
        {
            if (_isActive) return;
            
            transform.position = _startPoint.position;
            _isActive = true;
            _model.Activate();

        }
        private void ExplosionWall()
        {
            _model.Deactivate();
            _isActive = false;

            if(_detector.TryGetWall && _player.HasBomb)
            {
                var wall = _detector.GetWall();
                _player.ExplosionWall(wall.transform);
            }
        }
    }
}