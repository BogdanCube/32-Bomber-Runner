using Core.Player.Bag;
using DG.Tweening;
using Toolkit.Extensions;
using UnityEngine;

namespace Core
{
    public class Bomb : MonoBehaviour
    {
        [SerializeField] private float _gravity = 5;
        [SerializeField] private float _duration = 3;
        private Bag _bag;
        public void Jump(Vector3 startPosition, Vector3 endPosition, Bag bag)
        {
            transform.Activate();
            _bag = bag;
            transform.position = startPosition;
            transform.DOJump(endPosition, _gravity, 1, _duration)
                .SetEase(Ease.OutBack);
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Wall wall))
            {
                wall.Explosion(_bag);
                transform.Deactivate();
            }
        }
    }
}