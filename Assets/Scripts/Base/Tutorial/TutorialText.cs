using NaughtyAttributes;
using TMPro;
using UnityEngine;

namespace Base.Tutorial
{
    public class TutorialText : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private TextMeshProUGUI _text;

        [Button]
        private void Test()
        {
            Show();
        }
        public void Show()
        {
            _animator.SetTrigger("Show");
        }
        public void SetText(string text)
        {
            _text.text = text;
        }

        public void Hide()
        {
            _animator.SetTrigger("Hide");
        }
    }
}