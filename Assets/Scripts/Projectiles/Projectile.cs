using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    public enum ProjectileType
    {

    }

    public float Speed;
    public ProjectileType Type;

    public void StartMovement()
    {
        StartCoroutine(movementPattern());
    }

    //@todo: should be moving using rigidbody
    protected abstract IEnumerator movementPattern();

    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
        transform.localPosition = Vector3.zero;
        transform.rotation = Quaternion.identity;
    }
}
