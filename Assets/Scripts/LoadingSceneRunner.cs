using System.Collections;
using UnityEngine;

/// <summary>
/// A tiny persistent coroutine runner so async flows can survive scene loads.
/// </summary>
public sealed class LoadingSceneRunner : MonoBehaviour
{
    private static LoadingSceneRunner _instance;

    public static LoadingSceneRunner Instance
    {
        get
        {
            EnsureInstance();
            return _instance;
        }
    }

    public static void Run(IEnumerator routine)
    {
        EnsureInstance();
        _instance.StartCoroutine(routine);
    }

    private static void EnsureInstance()
    {
        if (_instance != null) return;

        GameObject go = new GameObject(nameof(LoadingSceneRunner));
        _instance = go.AddComponent<LoadingSceneRunner>();
        DontDestroyOnLoad(go);
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(gameObject);
    }
}


