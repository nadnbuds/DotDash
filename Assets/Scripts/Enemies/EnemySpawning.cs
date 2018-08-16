using UnityEngine;

public class EnemySpawning : Singleton<EnemySpawning>
{
    [SerializeField]
    private ObjectPooler EnemyPool;
    [SerializeField]
    private Enemy EnemyPrefab;

    [SerializeField]
    private ProjectilePooler pool;

    public Enemy GetEnemy()
    {
        Enemy enemy = Instantiate(EnemyPrefab) as Enemy;

        ProjectilePattern[] patterns = new ProjectilePattern[]
        {
            new WavePattern(90, 25, 5, 0.1f, 1),
            new WaitPattern(3.0f),
        };

        enemy.SetProjectilePool(Instantiate(pool));
        enemy.SetProjectilePatterns(patterns);

        return enemy;
    }
}
