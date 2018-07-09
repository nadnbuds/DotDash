using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DotInput
{
    public static class InputManager
    {
        private static Dictionary<string, Axis> axis = new Dictionary<string, Axis>();
        public static bool JoystickIsActive = true;

        public static void AddVirtualAxis(string id)
        {
            axis.Add(id, new Axis(id));
        }

        public static float GetAxis(string id)
        {
            return axis[id].Value;
        }

        public static void UpdateAxis(string id, float value)
        {
            axis[id].Value = value;
        }
    }
}
