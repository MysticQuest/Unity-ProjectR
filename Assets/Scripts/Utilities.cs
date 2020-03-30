using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Utility
{
    public static class Utilities
    {
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
    }
}