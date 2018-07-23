using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private ProjectilePooler pool;

    [SerializeField]
    private Enemy enemyPrefab;

    [SerializeField]
    private Player player;

    [SerializeField]
    private Button Begin;

    [SerializeField]
    public static int Level { get; private set; }

    private List<KeyValuePair<Rect, bool>> quadrants;

    private void Awake()
    {
        quadrants = new List<KeyValuePair<Rect, bool>>();
        Level = 0;

        Begin.onClick.AddListener(() => { Begin.gameObject.SetActive(false); });
        Begin.onClick.AddListener(Initialize);
    }

    private void Initialize()
    {
        Vector3 Size = UnityEngine.Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 1));
        Size -= UnityEngine.Camera.main.gameObject.transform.position;
        Size.x *= 2;

        Vector2 PosA = UnityEngine.Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 1));
        Vector2 PosB = UnityEngine.Camera.main.ViewportToWorldPoint(new Vector3(0, .5f, 1));
        Vector2 PosC = UnityEngine.Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 1));
        Rect A = new Rect(PosA, Size);
        SetupEnemy(A);
        quadrants.Add(new KeyValuePair<Rect, bool>(A, true));

        Rect B = new Rect(PosB, Size);
        SetupEnemy(B);
        quadrants.Add(new KeyValuePair<Rect, bool>(B, true));

        Rect C = new Rect(PosC, Size);
        quadrants.Add(new KeyValuePair<Rect, bool>(C, false));
    }

    private void Update()
    {
        for(int i = 0; i < quadrants.Count; ++i)
        {
            Vector2 bottomPos = quadrants[i].Key.center;
            bottomPos.y -= quadrants[i].Key.height/2;
            Vector2 topPos = quadrants[i].Key.center;
            topPos.y += quadrants[i].Key.height/2;
            if(CameraUtility.CheckInCameraSpace(bottomPos) && (quadrants[i].Value == false))
            {
                quadrants[i] = new KeyValuePair<Rect, bool>(quadrants[i].Key, true);
                Vector2 newCenter = quadrants[i].Key.center;
                newCenter.y += quadrants[i].Key.height;
                Rect newRect = new Rect(newCenter.x, newCenter.y, quadrants[i].Key.width, quadrants[i].Key.height);
                SetupEnemy(newRect);
                quadrants.Add(new KeyValuePair<Rect, bool>(newRect, false));
            }
            else if(CameraUtility.CheckInCameraSpace(topPos) && (quadrants[i].Value))
            {
                quadrants.RemoveAt(i);
            }
        }
    }

    private void SetupEnemy(Rect spawnRect)
    {
        Enemy enemy = Instantiate(enemyPrefab) as Enemy;

        enemy.transform.position = spawnRect.GetRandomPosition();

        ProjectilePattern[] patterns = new ProjectilePattern[]
{
            new WaitPattern(3.0f),
            new SimplePattern()
};

        enemy.SetProjectilePool(Instantiate(pool));
        enemy.SetProjectilePatterns(patterns);
        enemy.InitiateBulletPatterns();
    }
}
