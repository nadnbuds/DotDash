using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class ProjectilePattern
{
    public abstract IEnumerator ConstructPattern(Func<Projectile> GetProjectiles);
}
