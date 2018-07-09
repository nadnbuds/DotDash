using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DotInput;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = .1f;

    private Collider2D collider;
    private SpriteRenderer renderer;

    private void Awake()
    {
        collider = gameObject.GetComponent<Collider2D>();
        renderer = gameObject.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        collider.enabled = InputManager.JoystickIsActive;

        //@todo: Create alpha setter
        if(InputManager.JoystickIsActive == false)
        {
            renderer.color = new Color(renderer.color.r, renderer.color.g, renderer.color.b, .5f);
        }
        else
        {
            renderer.color = new Color(renderer.color.r, renderer.color.g, renderer.color.b, 1.0f);
        }

        Vector3 newPos = Vector3.zero;
        newPos.x = (InputManager.GetAxis(Joystick.Keys.xAxis) * moveSpeed);
        newPos.y = (InputManager.GetAxis(Joystick.Keys.yAxis) * moveSpeed);
        transform.position += newPos;
    }
}
