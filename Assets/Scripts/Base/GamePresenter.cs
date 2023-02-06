using Core.Player;
using UnityEngine;
using UnityEngine.Events;

namespace Base
{
    public class GamePresenter : MonoBehaviour
    {
        [SerializeField] private DeathPlayer _player;
        public UnityEvent OnInit;
        public UnityEvent OnStartGame;
        public UnityEvent OnWin;
        public UnityEvent OnLose;

        #region Enable / Disable

        private void OnEnable()
        {
            _player.OnDeath += Lose;
        }

        private void OnDisable()
        {
            _player.OnDeath -= Lose;
        }

        #endregion
        private void Awake()
        {
            OnInit?.Invoke();
        }

        public void StartGame()
        {
            OnStartGame?.Invoke();
        }
        public void Win()
        {
            OnWin?.Invoke();
        }
        private void Lose()
        {
            OnLose?.Invoke();
        }
    }
}