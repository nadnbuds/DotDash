using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Vector2 Position { get; private set; }

    private void Update()
    {
        Position = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Destroy(this.gameObject);
        //Debug.Log("Hit");
    }

    public void Death()
    {

    }
}
