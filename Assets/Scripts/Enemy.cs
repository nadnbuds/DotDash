using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private ProjectilePooler projectilePool;
    private ProjectilePattern[] projectilePatterns;

    public void SetProjectilePatterns(ProjectilePattern[] projectilePatterns)
    {
        this.projectilePatterns = projectilePatterns;
    }

    public void SetProjectilePool(ProjectilePooler projectilePool)
    {
        this.projectilePool = projectilePool;
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
