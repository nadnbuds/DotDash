using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Stasis;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Destroy(this.gameObject);
        //Debug.Log("Hit");
    }


}
