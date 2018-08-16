using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CameraUtility
{
    public static bool ClampPositionToCamera(ref Vector3 position)
    {
        bool clamped = false;

        Vector3 cameraPoint = UnityEngine.Camera.main.WorldToViewportPoint(position);
        cameraPoint.x = Mathf.Clamp01(cameraPoint.x);
        cameraPoint.y = Mathf.Clamp01(cameraPoint.y);
        if (cameraPoint.x == 1 || cameraPoint.x == 0 || cameraPoint.y == 1 || cameraPoint.y == 0)
        {
            clamped = true;
        }

        position = UnityEngine.Camera.main.ViewportToWorldPoint(cameraPoint);

        return clamped;
    }

    public static bool CheckInCameraSpace(Vector3 position)
    {
        Vector3 cameraPoint = UnityEngine.Camera.main.WorldToViewportPoint(position);

        return (cameraPoint.x <= 1 && cameraPoint.x >= 0) && (cameraPoint.y <= 1 && cameraPoint.y >= 0);
    }
}
