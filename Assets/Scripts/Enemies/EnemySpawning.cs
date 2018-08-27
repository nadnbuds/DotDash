using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : Singleton<EnemySpawning>
{
    private enum EnemyType
    {
        StationaryEnemy = 0,
        PatrollingEnemy,
        ChasingEnemy,
        CamouflageEnemy,
        MirrorEnemy
    }
    private enum BulletType
    {
        SimpleBullet = 0,
        BouncingBullet,
        ExplodingBullet,
        CurvingBullet,  //Bezier Curves
        ZigZagBullet,   //Non Bezier Curves
        TrackingBullet
    }
    private enum BulletPattern
    {
        WaitPattern = 0,
        WavePattern,
        CirclePattern,
        FollowPattern,
    }

    [SerializeField]
    List<EnemyType> EnemyTypes;

    public void InitializeEnemy(ref Enemy enemy)
    {
        ProjectilePattern[] patterns = new ProjectilePattern[]
        {
            new WavePattern(90, 25, 5, 0.1f, 1),
            new WaitPattern(3.0f),
        };

        enemy.SetProjectilePatterns(patterns);
    }
}
