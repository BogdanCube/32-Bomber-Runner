using UnityEngine;
using UnityEngine.Events;

namespace Base
{
    public class GamePresenter : MonoBehaviour
    {
        public UnityEvent OnInit;
        public UnityEvent OnStartGame;
        public UnityEvent OnWin;
        public UnityEvent OnLose;
        
        private void Awake()
        {
            OnInit?.Invoke();
        }

        public void StartGame()
        {
            OnStartGame?.Invoke();
        }
        private void Win()
        {
            OnWin?.Invoke();
        }
        private void Lose()
        {
            OnLose?.Invoke();
        }
    }
}