using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CameraUtility
{
    public static void ClampPositionToCamera(ref Vector3 position)
    {
        Vector3 cameraPoint = UnityEngine.Camera.main.WorldToViewportPoint(position);
        cameraPoint.x = Mathf.Clamp01(cameraPoint.x);
        cameraPoint.y = Mathf.Clamp01(cameraPoint.y);
        position = UnityEngine.Camera.main.ViewportToWorldPoint(cameraPoint);
    }

    public static bool CheckInCameraSpace(Vector3 position)
    {
        Vector3 cameraPoint = UnityEngine.Camera.main.WorldToViewportPoint(position);

        return (cameraPoint.x <= 1 && cameraPoint.x >= 0) && (cameraPoint.y <= 1 && cameraPoint.y <= 0);
    }
}
