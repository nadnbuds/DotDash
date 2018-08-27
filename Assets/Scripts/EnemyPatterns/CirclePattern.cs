using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CirclePattern : ProjectilePattern
{
    private const float Circumference = 2 * Mathf.PI;

    private int numAxisPoints;
    private int direction;
    private int numAxisBullets;
    private float bufferTimeBetweenBullets;

    private float ArcPerAxis
    {
        get
        {
            return (2 * Mathf.PI) / numAxisPoints;
        }
    }

    public CirclePattern(int numPoints, int numPerAxis, float bufferTime, int dir = 1)
    {
        numAxisPoints = numPoints;
        numAxisBullets = numPerAxis;
        bufferTimeBetweenBullets = bufferTime;
        direction = dir;
    }

    public override IEnumerator ConstructPattern(Func<Projectile> GetProjectiles)
    {
        yield return null;

        for (float a = 0; a < ArcPerAxis; a += (ArcPerAxis / numAxisBullets))
        {
            shootRing(a * direction, GetProjectiles);

            yield return new WaitForSeconds(bufferTimeBetweenBullets);
        }
    }

    private void shootRing(float offset, Func<Projectile> GetProjectiles)
    {
        for (float a = 0; a < Circumference; a += ArcPerAxis)
        {
            Projectile simple = GetProjectiles();

            simple.transform.Rotate(new Vector3(0, 0, Mathf.Rad2Deg * (a + offset)));
            simple.transform.position += simple.transform.up * (simple.transform.lossyScale.x/2);

            simple.gameObject.SetActive(true);
            simple.StartMovement();
        }
    }
}
