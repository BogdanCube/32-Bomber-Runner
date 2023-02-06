using Core.Player.Bag;
using UnityEngine;
using UnityEngine.Events;

namespace Base.Tutorial
{
    public class BagTriggerEvent : MonoBehaviour
    {
        [SerializeField] private Bag _bag;
        public UnityEvent OnTrigger;

        #region Enable / Disable

        private void OnEnable()
        {
            _bag.OnAdd += BagTrigger;
        }
        
        private void OnDisable()
        {
            _bag.OnAdd -= BagTrigger;
        }

        #endregion
        private void BagTrigger()
        {
            OnTrigger.Invoke();
        }
    }
}