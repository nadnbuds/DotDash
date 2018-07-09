using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePattern : ProjectilePattern
{
    public override IEnumerator ConstructPattern()
    {
        yield return null;

        for (float a = 0; a < Mathf.PI / 2; a += Mathf.PI / 24)
        {
            shootRing(a);

            yield return new WaitForSeconds(.1f);
        }
    }

    private void shootRing(float offset)
    {
        for (float a = 0; a < 2 * Mathf.PI; a += Mathf.PI / 4)
        {
            Projectile simple = projectilePool.GetProjectile();

            simple.transform.Rotate(new Vector3(0, 0, Mathf.Rad2Deg * (a + offset)));
            simple.transform.position += simple.transform.up * (simple.transform.lossyScale.x/2);

            simple.gameObject.SetActive(true);
            simple.StartMovement();
        }
    }
}
