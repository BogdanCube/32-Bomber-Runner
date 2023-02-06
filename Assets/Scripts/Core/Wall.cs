using System;
using System.Threading.Tasks;
using Core.Player.Bag;
using DG.Tweening;
using Toolkit.Extensions;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace Core
{
    public class Wall : MonoBehaviour
    {
        [SerializeField] private int _score;
        [SerializeField] private float _radius = 30;
        [SerializeField] private float _delayAdd = 1;
        [SerializeField] private ParticleSystem _particle;
        private Fragment[] _fragments;

        private void Start()
        {
            _fragments = GetComponentsInChildren<Fragment>();
        }
        public async void Explosion(Bag bag)
        {
            _particle.Activate();
            foreach (var fragment in _fragments)
            {
                fragment.Force(Random.insideUnitCircle.normalized * _radius);
            }

            await Task.Delay(TimeSpan.FromSeconds(_delayAdd));
            bag.Add(_score);
            transform.Deactivate();
        }
    }
}