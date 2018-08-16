using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingProjectile : Projectile
{
    protected override IEnumerator movementPattern()
    {
        while (true)
        {
            Vector3 forward = transform.up;
            transform.position += (forward * Speed * Time.deltaTime);
            Vector3 pos = transform.position;

            if(CameraUtility.ClampPositionToCamera(ref pos))
            {
                Vector3 LookDir = Vector3.Reflect(transform.up, Vector3.right);

                transform.up = LookDir;
            }

            yield return null;
        }
    }
}
