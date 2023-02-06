using UnityEngine;
using UnityEngine.UI;

namespace Core.Aim
{
    public class DetectorWall : MonoBehaviour
    {
        [SerializeField] private Image _image;
        private Wall _wall;
        public bool TryGetWall => _wall != null;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Wall wall))
            {
                _image.color = Color.green;
                _wall = wall;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out Wall wall))
            {
                _image.color = Color.white;
                _wall = null;
            }
        }
        
        public Wall GetWall()
        {
            var temp = _wall;
            _wall = null;
            _image.color = Color.white;
            return temp;
        }
    }
}