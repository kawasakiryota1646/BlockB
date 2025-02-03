using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 特定のシーンのBGMを続けて再生するスクリプト
/// </summary>
public class BGMcontinuation : MonoBehaviour
{
    private static BGMcontinuation instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // 特定のシーン名をチェック
        if (scene.name == "StageSelect")
        {
            Destroy(gameObject);
        }
    }
}
