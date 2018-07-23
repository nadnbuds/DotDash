using System.Collections;
using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private ProjectilePooler projectilePool;
    private ProjectilePattern[] projectilePatterns;
    private Action OnDeath;

    public void SetProjectilePatterns(ProjectilePattern[] projectilePatterns)
    {
        this.projectilePatterns = projectilePatterns;
    }

    public void SetProjectilePool(ProjectilePooler projectilePool)
    {
        this.projectilePool = projectilePool;
        this.projectilePool.transform.SetParent(this.transform);
        this.projectilePool.transform.localPosition = Vector3.zero;
    }

    public void InitiateBulletPatterns()
    {
        for (int i = 0; i < projectilePatterns.Length; ++i)
        {
            projectilePatterns[i].setPool(projectilePool);
        }

        StartCoroutine(LoopPattern());
    }

    private IEnumerator LoopPattern()
    {
        yield return null;
        while(true)
        {
            for(int i = 0; i < projectilePatterns.Length; ++i)
            {
                yield return StartCoroutine(projectilePatterns[i].ConstructPattern());
            }
        }
    }
}
