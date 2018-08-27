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

    public static Vector2 GetRandomPositionOutterRing(this Rect rect)
    {
        Vector2 result = Vector2.zero;
        if(Random.Range(0f, 1f) > .5f)
        {
            result.x = Random.Range(rect.xMin, (rect.xMin + rect.center.x) / 2);
        }
        else
        {
            result.x = Random.Range(rect.xMax, (rect.xMax + rect.center.x) / 2);
        }

        if(Random.Range(0f, 1f) > .5f)
        {
            result.y = Random.Range(rect.yMin, (rect.yMin + rect.center.y) / 2);
        }
        else
        {
            result.y = Random.Range(rect.yMax, (rect.yMax + rect.center.y) / 2);
        }

        return result;
    }
}
