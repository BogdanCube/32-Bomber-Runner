using UnityEngine;
using UnityEngine.Serialization;

namespace Core.Aim
{
    public class DetectorWall : MonoBehaviour
    {
        [SerializeField] private MeshRenderer _renderer;
        private Wall _wall;
        public bool TryGetWall => _wall != null;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Wall wall))
            {
                _renderer.material.color = Color.green;
                _wall = wall;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out Wall wall))
            {
                _renderer.material.color = Color.white;
                _wall = null;
            }
        }
        
        public Wall GetWall()
        {
            var temp = _wall;
            _wall = null;
            _renderer.material.color = Color.white;
            return temp;
        }
    }
}