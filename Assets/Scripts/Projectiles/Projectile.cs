using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
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
    protected IEnumerator movementPattern()
    {
        while (true)
        {
            Vector3 forward = transform.up;
            transform.position += (forward * Speed * Time.deltaTime);

            yield return null;
        }
    }

    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
        transform.localPosition = Vector3.zero;
        transform.rotation = Quaternion.identity;
    }
}
