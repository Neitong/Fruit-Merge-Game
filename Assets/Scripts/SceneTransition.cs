using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class LoadingResult
{
    public bool success;
    public string error;
}

/// <summary>
/// Loads a dedicated loading scene, runs a coroutine (e.g. API call),
/// then loads the target scene if success (or optional fail scene).
/// </summary>
public static class SceneTransition
{
    public const string DefaultLoadingSceneName = "LoadingScene";

    public static void LoadWithLoadingScene(
        IEnumerator operation,
        LoadingResult result,
        string successScene,
        string loadingScene = DefaultLoadingSceneName,
        string failScene = null)
    {
        LoadingSceneRunner.Run(Run(operation, result, successScene, loadingScene, failScene));
    }

    private static IEnumerator Run(
        IEnumerator operation,
        LoadingResult result,
        string successScene,
        string loadingScene,
        string failScene)
    {
        result.success = false;
        result.error = null;

        SceneManager.LoadScene(loadingScene);
        yield return null; // give the loading scene 1 frame to show

        yield return operation;

        if (result.success)
        {
            SceneManager.LoadScene(successScene);
            yield break;
        }

        Debug.LogError("Operation failed" + (string.IsNullOrEmpty(result.error) ? "" : $": {result.error}"));

        if (!string.IsNullOrEmpty(failScene))
        {
            SceneManager.LoadScene(failScene);
        }
    }
}


