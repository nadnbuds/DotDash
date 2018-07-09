using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace DotInput
{
    public class InputHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
    {
        public void OnDrag(PointerEventData eventData)
        {
            Joystick.ActiveJoystick.OnDrag(eventData);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            Joystick.ActiveJoystick.OnPointerDown(eventData);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            Joystick.ActiveJoystick.OnPointerUp(eventData);
        }
    }
}
