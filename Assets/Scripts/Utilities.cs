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

        // Screen Shake by codemonkey
        public static void ShakeCamera(float intensity, float timer)
        {
            Vector3 lastCameraMovement = Vector3.zero;
            timer -= Time.unscaledDeltaTime;
            Vector3 randomMovement = new Vector3(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f)).normalized * intensity;
            Camera.main.transform.position = Camera.main.transform.position - lastCameraMovement + randomMovement;
            lastCameraMovement = randomMovement;
            // return timer <= 0f;
        }
    }
}