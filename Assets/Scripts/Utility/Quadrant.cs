using System;
using UnityEngine;

public class Quadrant : MonoBehaviour
{
    private Rect box;
    private Enemy enemy;
    private Action QuadrantEnterView;
    private Action QuadrantExitView;
    private bool inCameraView;
    private bool hitCheckpoint;

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

    public void SetOnExitView(Action action)
    {
        QuadrantExitView = action;
    }

    public void SetOnEnterView(Action action)
    {
        QuadrantEnterView = action;
    }

    public void Initialize(Vector2 Center, Vector2 Size)
    {
        inCameraView = false;

        box = new Rect();
        box.size = Size;
        box.center = Center;

        transform.position = Center;
        transform.localScale = Size;

        SetupEnemy();
    }

    private void SetupEnemy()
    {
        Vector2 pos = box.GetRandomPosition();

        enemy = EnemySpawning.instance.GetEnemy();

        enemy.transform.position = pos;
        enemy.transform.SetParent(this.transform);

        enemy.InitiateBulletPatterns();
    }

    private void Update()
    {
        if (inCameraView &&
            hitCheckpoint == false &&
            Player.Position.y > enemy.transform.position.y)
        {
            hitCheckpoint = true;
            GameManager.instance.Level++;
        }

        if (CameraUtility.CheckInCameraSpace(bottomPos) &&
            inCameraView == false)
        {
            inCameraView = true;
            QuadrantEnterView();
        }
        else if (CameraUtility.CheckInCameraSpace(topPos) == false &&
            CameraUtility.CheckInCameraSpace(bottomPos) == false &&
            inCameraView)
        {
            inCameraView = false;
            QuadrantExitView();
        }
    }

    public static Vector3 GetQuadSize()
    {
        Vector3 quadSize = UnityEngine.Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 1));
        quadSize -= UnityEngine.Camera.main.gameObject.transform.position;
        quadSize.x *= 2;

        return quadSize;
    }
}
