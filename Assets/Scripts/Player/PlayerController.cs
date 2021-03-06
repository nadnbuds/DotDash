﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DotInput;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = .1f;

    private Collider2D collider;
    private SpriteRenderer renderer;
    private Player player;

    private void Awake()
    {
        collider = gameObject.GetComponent<Collider2D>();
        renderer = gameObject.GetComponent<SpriteRenderer>();
        player = gameObject.GetComponent<Player>();
    }

    private void Update()
    {
        if(InputManager.JoystickIsActive == false)
        {
            Time.timeScale = .1f;
        }
        else
        {
            Time.timeScale = 1f;
        }

        Vector3 newPos = Vector3.zero;
        newPos.x = (InputManager.GetAxis(Joystick.Keys.xAxis) * moveSpeed);
        newPos.y = (InputManager.GetAxis(Joystick.Keys.yAxis) * moveSpeed);
        newPos += transform.position;
        CameraUtility.ClampPositionToCamera(ref newPos);
        transform.position = newPos;
    }
}
