﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleProjectile : Projectile
{
    protected override IEnumerator movementPattern()
    {
        while (true)
        {
            Vector3 forward = transform.up;
            transform.position += (forward * Speed * Time.deltaTime);

            yield return null;
        }
    }
}
