using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CoroutineUtility
{
    private static MonoBehaviour mono;
    public static MonoBehaviour Mono
    {
        get
        {
            if(mono == null)
            {
                mono = new GameObject().AddComponent<EmptyMonoBehaviour>();
            }

            return mono;
        }
    }
}
