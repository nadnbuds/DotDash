using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    [SerializeField]
    public Player Player { get; private set; }

    [SerializeField]
    private Button Begin;

    [SerializeField]
    private Text levelText;

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

    private List<Quadrant> quadrants;

    private void Awake()
    {
        quadrants = new List<Quadrant>();
        Level = 0;

        Begin.onClick.AddListener(() => { Begin.gameObject.SetActive(false); });
        Begin.onClick.AddListener(InitializeQuadrants);
    }

    private void InitializeQuadrants()
    {
        createQuadrant(UnityEngine.Camera.main.ViewportToWorldPoint(new Vector3(.5f, .25f, 1))).SetOnEnterView(() => { });
        createQuadrant(UnityEngine.Camera.main.ViewportToWorldPoint(new Vector3(.5f, .75f, 1))).SetOnEnterView(() => { });

        createNewQuadrant();
    }

    private void createNewQuadrant()
    {
        //@todo: Mathimatically computer the y value
        Vector3 Pos = quadrants[quadrants.Count - 1].transform.position;
        Pos.y += Quadrant.GetQuadSize().y;
        createQuadrant(Pos).SetOnEnterView(createNewQuadrant);
    }

    private Quadrant createQuadrant(Vector3 pos)
    {
        Quadrant quad = new GameObject().AddComponent<Quadrant>();
        quad.Initialize(pos, Quadrant.GetQuadSize());
        quad.SetOnExitView(() => { quad.gameObject.SetActive(false); });
        quadrants.Add(quad);

        return quad;
    }
}
