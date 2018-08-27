using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitPattern : ProjectilePattern
{
    private float timeToWait;

    public WaitPattern(float timeToWait)
    {
        this.timeToWait = timeToWait;
    }

    public override IEnumerator ConstructPattern(Func<Projectile> GetProjectiles)
    {
        Debug.Log($"Started: {Time.time}");
        yield return new WaitForSeconds(timeToWait);
        Debug.Log($"Finished: {Time.time}");
    }
}
