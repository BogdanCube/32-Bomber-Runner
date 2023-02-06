using System;
using NaughtyAttributes;
using UnityEngine;

namespace Core.Player.Bag
{
    public class Bag : MonoBehaviour
    {
        private int _count;
        public event Action OnAdd;
        public event Action<int> OnUpdateCount;
        public bool IsHave => _count > 0;
        
        [Button]
        public void Add(int score = 1)
        {
            _count+= score;
            OnAdd?.Invoke();
            OnUpdateCount?.Invoke(_count);
        }
        
        [Button]
        public void Spend()
        {
            _count--;
            OnUpdateCount?.Invoke(_count);
        }
    }
}