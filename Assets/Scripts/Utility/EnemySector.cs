using System;
using UnityEngine;

public class EnemySector : MonoBehaviour
{
    private Rect box;
    private Enemy enemy;
    private bool sectorPassed;

    public Vector2 Size
    {
        get
        {
            return box.size;
        }
        set
        {
            box.size = value;
        }
    }

    public Vector2 Center
    {
        get
        {
            return box.center;
        }
        set
        {
            box.center = value;
        }
    }

    private Vector2 topPos
    {
        get
        {
            Vector2 pos = Center;
            pos.y += Size.y / 2;

            return pos;
        }
    }

    private Vector2 bottomPos
    {
        get
        {
            Vector2 pos = Center;
            pos.y -= Size.y / 2;

            return pos;
        }
    }

    public void Initialize(Vector2 Center, Vector2 Size)
    {
        sectorPassed = false;

        EnemySpawning.instance.InitializeEnemy(ref enemy);

        box = new Rect();
        box.size = Size;
        box.center = Center;

        transform.position = Center;
        transform.localScale = Size;

        gameObject.SetActive(true);
    }

    private void Update()
    {
        if(Player.Position.y > topPos.y)
        {
            if(sectorPassed == false)
            {
                sectorPassed = true;
                GameManager.instance.Level++;
            }

            if (CameraUtility.CheckInCameraSpace(topPos) == false &&
                CameraUtility.CheckInCameraSpace(bottomPos) == false)
            {
                gameObject.SetActive(false);
                GameManager.instance.ResetQuadrant();
            }
        }
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.DrawCube(Center, Size);
    }
#endif

}
