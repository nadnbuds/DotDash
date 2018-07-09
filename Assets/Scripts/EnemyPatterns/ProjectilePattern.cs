using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class ProjectilePattern
{
    protected ProjectilePooler projectilePool;
    public abstract IEnumerator ConstructPattern();

    public void setPool(ProjectilePooler projectilePooler)
    {
        projectilePool = projectilePooler;
    }
}
