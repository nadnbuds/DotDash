using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    private const int SectorCount = 4;

    [SerializeField]
    public Player Player { get; private set; }

    [SerializeField]
    private Button Begin;

    [SerializeField]
    private Text levelText;

    private LinkedList<EnemySector> enemySectors;
    private Vector3 SectorSize;

    private int level;
    public int Level
    {
        get
        {
            return level;
        }
        set
        {
            levelText.text = value.ToString();
            level = value;
        }
    }

    private Vector2 IncomingSectorPosition
    {
        get
        {
            return UnityEngine.Camera.main.ViewportToWorldPoint(new Vector3(.5f, .75f, 1));
        }
    }

    private void Awake()
    {
        Level = 0;

        enemySectors = new LinkedList<EnemySector>();
        SectorSize = GetQuadSize();

        Begin.onClick.AddListener(() => { Begin.gameObject.SetActive(false); });
        Begin.onClick.AddListener(InitializeSectors);
    }

    private void InitializeSectors()
    {
        LinkedListNode<EnemySector> sectorNode = enemySectors.First;
        sectorNode.Value.Initialize(UnityEngine.Camera.main.ViewportToWorldPoint(new Vector3(.5f, .25f, 1)), SectorSize);

        sectorNode = sectorNode.Next;
        sectorNode.Value.Initialize(UnityEngine.Camera.main.ViewportToWorldPoint(new Vector3(.5f, .75f, 1)), SectorSize);

        sectorNode = sectorNode.Next;
        sectorNode.Value.Initialize(IncomingSectorPosition, SectorSize);
    }

    public void ResetQuadrant()
    {
        enemySectors.Last.Value.Initialize(IncomingSectorPosition, SectorSize);
        enemySectors.AddLast(enemySectors.First);
        enemySectors.RemoveFirst();
    }

    public Vector3 GetQuadSize()
    {
        Vector3 quadSize = UnityEngine.Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 1));
        quadSize -= UnityEngine.Camera.main.gameObject.transform.position;
        quadSize.x *= 2;

        return quadSize;
    }
}
