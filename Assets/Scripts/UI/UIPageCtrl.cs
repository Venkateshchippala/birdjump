using UnityEngine;

    public class UIPageCtrl : MonoBehaviour
    {
        [Header("Page Elements")]
        public UIElement[] uiElements;

        private void Awake()
        {
            uiElements = GetComponentsInChildren<UIElement>();
        }

        public void PlayInEffect()
        {
            foreach (UIElement element in uiElements)
            {
                element.PlayInEffect();
            }
        }

        public void PlayOutEffect()
        {
            foreach (UIElement element in uiElements)
            {
                element.PlayOutEffect();
            }
        }
    }
