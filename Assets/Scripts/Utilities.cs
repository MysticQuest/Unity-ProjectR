using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Utility
{
    public static class Utilities
    {
        //get mouse position
        public static Vector3 GetMousePosition()
        {
            Vector3 mousePos = GetWorldPointScreen(Input.mousePosition, Camera.main);
            mousePos.z = 0f;
            return mousePos;
        }
        public static Vector3 GetWorldPointScreen(Vector3 screenPosition, Camera camera)
        {
            Vector3 worldPosition = camera.ScreenToWorldPoint(screenPosition);
            return worldPosition;
        }

        //codemonkey utils
        public static float GetAngleFromVectorFloat(Vector3 dir)
        {
            dir = dir.normalized;
            float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            if (n < 0) n += 360;

            return n;
        }
    }
}