using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePooler : MonoBehaviour
{
    [SerializeField]
    private int numToPopulate = 100;
    [SerializeField]
    private Projectile projectilePrefab;
    private List<Projectile> projectilePool;

    private int lastIndex
    {
        get
        {
            return projectilePool.Count - 1;
        }
    }

    private void Awake()
    {
        projectilePool = new List<Projectile>();
        for(int i = 0; i < numToPopulate; ++i)
        {
            CreateProjectile();
        }
    }

    public Projectile GetProjectile()
    {
        for(int i = 0; i < projectilePool.Count; ++i)
        {
            if(projectilePool[i].gameObject.activeInHierarchy == false)
            {
                return projectilePool[i];
            }
        }

        Debug.LogError("Ran Out of Pooled Objectcs, creating new one");
        CreateProjectile();

        return projectilePool[lastIndex];
    }

    private void CreateProjectile()
    {
        projectilePool.Add(Instantiate(projectilePrefab));
        projectilePool[lastIndex].transform.position = this.transform.position;
        projectilePool[lastIndex].transform.SetParent(this.transform);
        projectilePool[lastIndex].gameObject.SetActive(false);
    }
}
