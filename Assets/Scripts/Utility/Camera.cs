using UnityEngine;

public class Camera : MonoBehaviour
{
    private void Update()
    {
        if(Player.Position.y > this.transform.position.y)
        {
            Vector3 movement = Vector3.zero;
            movement.y += Player.Position.y - this.transform.position.y;
            transform.position += movement;
        }
    }
}
