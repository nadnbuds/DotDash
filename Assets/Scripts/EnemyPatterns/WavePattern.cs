using System;
using System.Collections;
using UnityEngine;

public class WavePattern : ProjectilePattern
{
    private float timeToShoot;
    private float arc;
    private float speed;
    private float bufferTime;
    private float startingAngle;

    public WavePattern(float startingAngle, float arc, float speed, float bufferTime, float timeToShoot)
    {
        this.arc = arc;
        this.speed = speed;
        this.bufferTime = bufferTime;
        this.timeToShoot = timeToShoot;
        this.startingAngle = startingAngle;
    }

    public override IEnumerator ConstructPattern(Func<Projectile> GetProjectiles)
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
                Projectile simple = GetProjectiles();

                float angle = startingAngle + Mathf.Sin(Time.time * speed) * arc;
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
