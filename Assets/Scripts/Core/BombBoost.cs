using DG.Tweening;
using UnityEngine;

namespace Core
{
    public class BombBoost : MonoBehaviour
    {
       [SerializeField] private Vector3 _rotation;
       private Tween _tween;

       private void Start()
        {
            _tween = transform.DORotate(_rotation, 2f).SetLoops(-1).SetEase(Ease.Linear);
        }

       private void OnDisable()
       {
           _tween.Kill();
       }
    }
}