using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class ObjectPooler : MonoBehaviour
{
    [SerializeField]
    private GameObject objToClone;

    [SerializeField]
    private int numToClone;

    private GameObject[] pool;

    private void Awake()
    {
        pool = new GameObject[numToClone];
        for(int i = 0; i < numToClone; ++i)
        {
            pool[i] = Instantiate(objToClone);
            pool[i].SetActive(false);
            pool[i].transform.SetParent(this.transform);
        }
    }

    public GameObject GetGameObject()
    {
        Assert.IsFalse(pool[pool.Length - 1].gameObject.activeInHierarchy);

        for(int i = 0; i < pool.Length; ++i)
        {
            if(pool[i].gameObject.activeInHierarchy == false)
            {
                return pool[i];
            }
        }

        return new GameObject();
    }
}
