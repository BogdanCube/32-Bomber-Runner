using System.Collections.Generic;
using UnityEngine;

namespace Core.Player.Bag
{
    public class PresenterBag : MonoBehaviour
    {
        [SerializeField] private Bag _bag;
        [SerializeField] private GameObject _prefab;
        [SerializeField] private Transform _parent;
        [SerializeField] private float _offset;
        private readonly List<GameObject> _bricks = new();

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
        private void UpdateCount(int count)
        {
            if (count > _bricks.Count)
            {
                var difference = count - _bricks.Count;
                for (var i = 0; i < difference; i++)
                {
                    AddBrick();
                }
            }
            else
            {
                var difference = _bricks.Count - count;
                for (var i = 0; i < difference; i++)
                {
                    RemoveBlock();
                }
            }
        }
    
        private void AddBrick()
        {
            var block = Instantiate(_prefab, _parent);
            block.transform.localPosition = GetNextHeight();
            _bricks.Add(block);
        }
        private void RemoveBlock()
        {
            if (_bricks.Count <= 0) return;
            var brick = _bricks[^1];
            _bricks.Remove(brick);
            Destroy(brick.gameObject);
        }
        private Vector3 GetNextHeight()
        {
            var height = _bricks.Count * _offset + _offset;
            return new Vector3(0, height, 0);
        }
    }
}