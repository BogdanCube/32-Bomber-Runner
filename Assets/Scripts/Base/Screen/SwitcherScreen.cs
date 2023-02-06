using NaughtyAttributes;
using UnityEngine;

namespace Base.Screen
{
    public class SwitcherScreen : MonoBehaviour
    {
        [ShowNonSerializedField] private UIScreen _currentScreen;
        
        public void SetScreen(UIScreen screen)
        {
            if (_currentScreen != null)
            {
                _currentScreen.Hide(screen.Show);
            }
            else
            {
               screen.Show();
            }
            _currentScreen = screen;
        }
    }
}