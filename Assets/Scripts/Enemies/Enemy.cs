using System.Collections;
using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private ObjectPooler projectilePool;

    private ProjectilePattern[] projectilePatterns;

    public void SetProjectilePatterns(ProjectilePattern[] projectilePatterns)
    {
        this.projectilePatterns = projectilePatterns;
    }

    public void InitiateBulletPatterns()
    {
        StartCoroutine(LoopPattern());
    }

    private Projectile GetProjectile()
    {
        GameObject go = projectilePool.GetGameObject();
        Projectile projectile = go.GetComponent<Projectile>();
        projectile = (SimpleProjectile)projectile;

        return projectile;
    }

    private IEnumerator LoopPattern()
    {
        yield return null;
        while(true)
        {
            for(int i = 0; i < projectilePatterns.Length; ++i)
            {
                yield return StartCoroutine(projectilePatterns[i].ConstructPattern(GetProjectile));
            }
        }
    }
}
