using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemy : Enemy
{
    [SerializeField]
    private float moveDistance;

    private float awakeTime;

    private void Awake()
    {
        awakeTime = Random.value * moveDistance;
    }

    private void Update()
    {
        transform.position = new Vector3(Mathf.PingPong(Time.time - awakeTime, moveDistance) - (moveDistance / 2), transform.position.y, transform.position.z);
    }
}
