using System.Collections;
using UnityEngine;

public class FollowPattern : ProjectilePattern
{
    private float timeToShoot;
    private float bufferTime;

    public FollowPattern(float timeToShoot, float bufferTime)
    {
        this.timeToShoot = timeToShoot;
        this.bufferTime = bufferTime;
    }

    public override IEnumerator ConstructPattern()
    {
        yield return null;

        float timer = timeToShoot;
        float buffer = bufferTime;
        while(timer > 0)
        {
            timer -= Time.deltaTime;
            buffer -= Time.deltaTime;
            if(buffer < 0)
            {
                Projectile simple = projectilePool.GetProjectile();

                Vector2 lookDir = Player.Position - new Vector2(simple.transform.position.x, simple.transform.position.y);
                float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90;
                simple.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                simple.transform.position += simple.transform.up * (simple.transform.lossyScale.x / 2);

                simple.gameObject.SetActive(true);
                simple.Speed = 5f;
                simple.StartMovement();

                buffer = bufferTime;
            }

            yield return null;
        }
    }
}
