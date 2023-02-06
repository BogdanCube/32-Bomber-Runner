using System.Threading.Tasks;
using Toolkit.Extensions;
using UnityEngine;

namespace Core.Player
{
    public class AnimationPlayer : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        private readonly int _runningNameId = Animator.StringToHash("IsRunning");
        private readonly int _deathNameId = Animator.StringToHash("Death");
        private readonly int _attackNameId = Animator.StringToHash("Attack");
        private bool _isRunning;

        public bool IsRunning
        {
            get => _isRunning;
            set
            {
                if (value != _isRunning)
                {
                    _isRunning = value;
                    _animator.SetBool(_runningNameId, value);
                }
            }
        }
        public void SetDeath() => 
            _animator.SetTrigger("Death");
        public void SetAttack() => 
            _animator.SetTrigger("Attack");
    }
}