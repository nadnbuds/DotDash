using System.Collections;
using UnityEngine;

public class ExplosiveProjectile : Projectile
{
    [SerializeField]
    private float timeToExplode;

    [SerializeField]
    private float warningTime;

    [SerializeField]
    private float explosionRadius;

    Color explodingColor;

    public ExplosiveProjectile(float explosionRadius, float timeToExplode, float warningTime)
    {
        this.timeToExplode = timeToExplode;
        this.warningTime = warningTime;
        this.explosionRadius = explosionRadius;
    }

    protected override IEnumerator movementPattern()
    {
        explodingColor = new Color(1, 0, 0, 1);

        float timer = timeToExplode;
        while (true)
        {
            Vector3 forward = transform.up;
            transform.position += (forward * Speed * Time.deltaTime);

            timer -= Time.deltaTime;
            if(timer < warningTime)
            {
                Color initColor = GetComponent<SpriteRenderer>().color;

                GetComponent<SpriteRenderer>().color = Color.Lerp(initColor, explodingColor, 1 - (timer / warningTime));

                if(timer < 0)
                {
                    //Explosion Animation
                    Vector3 explosionPos = transform.position;
                    Collider[] colliders = Physics.OverlapSphere(explosionPos, explosionRadius);
                    foreach (Collider hit in colliders)
                    {
                        Rigidbody rb = hit.GetComponent<Rigidbody>();

                        if (rb != null)
                            rb.AddExplosionForce(5.0f, explosionPos, explosionRadius, 3.0F);

                        Player player = hit.GetComponent<Player>();
                        if(player != null)
                        {
                            player.Death();
                        }
                    }
                }
            }

            yield return null;
        }
    }
}
