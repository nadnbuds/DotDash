using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RectExtensions
{
    public static Vector2 GetRandomPosition(this Rect rect)
    {
        Vector2 result = Vector2.zero;
        result.x = Random.Range(rect.xMin, rect.xMax);
        result.y = Random.Range(rect.yMin, rect.yMax);

        return result;
    }
}
