using UnityEngine;

    public class UIElement : MonoBehaviour
    {
        [Header("Element Settings")]
        [SerializeField] UIEffect effect;
        [SerializeField] Direction movementDirection;
        [SerializeField] float animationTime = 0.5f;
        [SerializeField] float animationDelay = 0f;
        [SerializeField] iTween.EaseType easeType = iTween.EaseType.easeInOutExpo;

        private Vector3 initialPosition;
        private Vector3 initialScale;
        public enum UIEffect
        {
            Scale, Movement
        }
        public enum Direction
        {
            Top,Bottom,Left,Right
        }

        private void Awake()
        {
            initialPosition = transform.localPosition;
            initialScale = transform.localScale;
        }

        public void PlayInEffect()
        {
            if (effect==UIEffect.Scale)
            {
                transform.localScale = Vector3.zero;
                iTween.ScaleTo(gameObject, iTween.Hash(
                    "scale", initialScale,
                    "time", animationTime,
                    "easetype", easeType,
                    "delay", animationDelay
                ));
            }

            if (effect == UIEffect.Movement)
            {
                Vector3 startPos = initialPosition;
                switch (movementDirection)
                {
                    case Direction.Top:
                        startPos = new Vector3(initialPosition.x, Screen.height, initialPosition.z);
                        break;
                    case Direction.Bottom:
                        startPos = new Vector3(initialPosition.x, -Screen.height, initialPosition.z);
                        break;
                    case Direction.Left:
                        startPos = new Vector3(-Screen.width, initialPosition.y, initialPosition.z);
                        break;
                    case Direction.Right:
                        startPos = new Vector3(Screen.width, initialPosition.y, initialPosition.z);
                        break;
                }

                transform.localPosition = startPos;
                iTween.MoveTo(gameObject, iTween.Hash(
                    "position", initialPosition,
                    "islocal", true,
                    "time", animationTime,
                    "easetype", easeType,
                    "delay", animationDelay
                ));
            }
        }

        public void PlayOutEffect()
        {
            if (effect == UIEffect.Scale)
            {
                iTween.ScaleTo(gameObject, iTween.Hash(
                    "scale", Vector3.zero,
                    "time", animationTime,
                    "easetype", easeType,
                    "delay", animationDelay
                ));
            }

            if (effect == UIEffect.Movement)
            {
                Vector3 endPos = initialPosition;
                switch (movementDirection)
                {
                    case Direction.Top:
                        endPos = new Vector3(initialPosition.x, Screen.height, initialPosition.z);
                        break;
                    case Direction.Bottom:
                        endPos = new Vector3(initialPosition.x, -Screen.height, initialPosition.z);
                        break;
                    case Direction.Left:
                        endPos = new Vector3(-Screen.width, initialPosition.y, initialPosition.z);
                        break;
                    case Direction.Right:
                        endPos = new Vector3(Screen.width, initialPosition.y, initialPosition.z);
                        break;
                }

                iTween.MoveTo(gameObject, iTween.Hash(
                    "position", endPos,
                    "islocal", true,
                    "time", animationTime,
                    "easetype", easeType,
                    "delay", animationDelay
                ));
            }
        }
    }
