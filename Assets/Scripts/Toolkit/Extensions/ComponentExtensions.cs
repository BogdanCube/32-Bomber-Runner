using UnityEngine;

namespace Toolkit.Extensions
{
    public static class ComponentExtensions
    {
        public static bool IsActive(this Component component)
        {
            var gameObject = component.gameObject;
            return gameObject != null && gameObject.activeSelf;
        }

        public static void SetStateActivate(this Component component, bool state)
        {
            if (component.gameObject != null) component.gameObject.SetActive(state);
        }
        public static void Activate(this Component component)
        {
            if (IsActive(component)) return;
            if (component.gameObject != null) component.gameObject.SetActive(true);
        }
        public static void Deactivate(this Component component)
        {
            if (IsActive(component) == false) return;
            if (component.gameObject != null) component.gameObject.SetActive(false);
        }
    }
}