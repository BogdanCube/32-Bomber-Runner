using System;
using System.Collections;
using UnityEngine;

namespace Core.Player
{
    public class DeathPlayer : MonoBehaviour
    {
        [SerializeField] private float _repeatDelay = 0.2f;
        [SerializeField] private Bag.Bag _bag;
        [SerializeField] private AnimationPlayer _animation;
        [SerializeField] private MoverPlayer _mover;
        [SerializeField] private GameObject _antiLavaBrick;
        private IEnumerator _coroutine;
        private bool _isDeath;
        
        public event Action OnDeath;
        private void Start()
        {
            _coroutine = TriggerCoroutine();
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<Lava>())
            {
                StartCoroutine(_coroutine);
            } 
            if (other.GetComponent<Wall>())
            {
                Death();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.GetComponent<Lava>())
            {
                StopCoroutine(_coroutine);
            }
        }

        private IEnumerator TriggerCoroutine()
        {
            while (true)
            {
                if (_bag.IsHave)
                {
                    _bag.Spend();
                    Instantiate(_antiLavaBrick, transform.position, Quaternion.identity);
                }
                else
                {
                    Death();
                    yield break;
                }
                yield return new WaitForSeconds(_repeatDelay);
            }
        }

        private void Death()
        {
            if (_isDeath) return;
            _isDeath = true;
            _mover.Stop();
            _animation.SetDeath();
            OnDeath?.Invoke();
        }
    }
}