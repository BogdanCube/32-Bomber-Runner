using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoLayout3D;
using UnityEngine;

namespace Core.Player.Bag
{
    public class PresenterBag : MonoBehaviour
    {
        [SerializeField] private Bag _bag;
        [SerializeField] private float _duration = 0.1f;
        [SerializeField] private LayoutElement3D _prefab;
        [SerializeField] private Transform _parent;
        private readonly List<LayoutElement3D> _bricks = new();

        #region Enable / Disable

        private void OnEnable()
        {
            _bag.OnUpdateCount += UpdateCount;
        }
        
        private void OnDisable()
        {
            _bag.OnUpdateCount -= UpdateCount;
        }

        #endregion
        private async void UpdateCount(int count)
        {
            if (count > _bricks.Count)
            {
                var difference = count - _bricks.Count;
                for (var i = 0; i < difference; i++)
                {
                    AddBrick();
                    await Task.Delay(TimeSpan.FromSeconds(_duration));
                }
            }
            else
            {
                var difference = _bricks.Count - count;
                for (var i = 0; i < difference; i++)
                {
                    RemoveBlock();
                    await Task.Delay(TimeSpan.FromSeconds(_duration));
                }
            }
        }
    
        private void AddBrick()
        {
            var block = Instantiate(_prefab, _parent);
            _bricks.Add(block);
        }
        private void RemoveBlock()
        {
            if (_bricks.Count <= 0) return;
            var brick = _bricks[^1];
            _bricks.Remove(brick);
            Destroy(brick.gameObject);
        }
    }
}