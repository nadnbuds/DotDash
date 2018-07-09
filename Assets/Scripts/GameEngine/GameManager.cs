using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Enemy enemy;
    [SerializeField]
    private ProjectilePooler pool;

    private void Awake()
    {
        ProjectilePattern[] patterns = new ProjectilePattern[]
        {
            new WaitPattern(3.0f),
            new SimplePattern()
        };

        enemy.SetProjectilePool(pool);
        enemy.SetProjectilePatterns(patterns);

        enemy.InitiateBulletPatterns();
    }
}
