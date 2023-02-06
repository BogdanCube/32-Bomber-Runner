using System;
using DG.Tweening;
using NaughtyAttributes;
using Toolkit.Extensions;
using UnityEngine;

namespace Core.Player
{
    public class BombPlayer : MonoBehaviour
    {
        [SerializeField] private Bomb _bomb;
        [SerializeField] private Bag.Bag _bag;
        [SerializeField] private SkinnedMeshRenderer _renderer;
        [SerializeField] private AnimationPlayer _animation;
        public bool IsExplosion { get; private set; }
        public bool HasBomb { get; private set; }

        #region Enable / Disable

        private void OnEnable()
        {
            _bag.OnAdd += UnExplosion;
        }
        private void OnDisable()
        {
            _bag.OnAdd -= UnExplosion;
        }

        #endregion
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out BombBoost boost))
            {
                HasBomb = true;
                boost.Deactivate();
                _renderer.material.DOColor(Color.red,1f);
            }
        }
        public void ExplosionWall(Transform wall)
        {
            IsExplosion = true;
            HasBomb = false;
            _animation.SetAttack();
            _bomb.Jump(transform.position,
                wall.position, _bag);
        }
        
        private void UnExplosion()
        {
            if (IsExplosion)
            {
                _renderer.material.DOColor(Color.white,1f);
                IsExplosion = false;
            }
        }
    }
}