using UnityEngine;
using UnityEngine.EventSystems;

namespace DotInput
{
    public class Joystick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
    {
        public class Keys
        {
            public const string xAxis = "joystick_x_axis";
            public const string yAxis = "joystick_y_axis";
        }

        private Vector3 initialPosition;

        [SerializeField]
        private float radiusRatio = .1f;
        private float radius;
        private bool useX = true, useY = true;

        public static Joystick ActiveJoystick { get; private set; }

        private void Awake()
        {
            ActiveJoystick = this;
            radius = radiusRatio * Screen.width;

            InputManager.AddVirtualAxis(Keys.xAxis);
            InputManager.AddVirtualAxis(Keys.yAxis);

            gameObject.SetActive(false);
        }

        private void updateAxis(Vector3 positionOffset)
        {
            positionOffset /= radius;
            InputManager.UpdateAxis(Keys.xAxis, positionOffset.x);
            InputManager.UpdateAxis(Keys.yAxis, positionOffset.y);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            gameObject.SetActive(true);
            InputManager.JoystickIsActive = true;
            initialPosition = eventData.position;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            updateAxis(Vector3.zero);
            InputManager.JoystickIsActive = false;
            gameObject.SetActive(false);
        }

        public void OnDrag(PointerEventData eventData)
        {
            Vector3 newPosition = Vector3.zero;
            
            if(useX)
            {
                float delta = eventData.position.x - initialPosition.x;
                newPosition.x = delta;
            }
            
            if(useY)
            {
                float delta = eventData.position.y - initialPosition.y;
                newPosition.y = delta;
            }

            newPosition = Vector3.ClampMagnitude(newPosition, radius);
            updateAxis(newPosition);

            transform.position = newPosition + initialPosition;
        }
    }
}
