using Core.Player.Bag;
using MoreMountains.NiceVibrations;
using UnityEngine;

namespace Base
{
    public class PlayerVibration : MonoBehaviour
    {
        [SerializeField] private Bag _bag;

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
            MMVibrationManager.Haptic (HapticTypes.Selection);
        }

    }
}