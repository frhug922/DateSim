using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    #region Singleton

    public static SceneManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this) {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    #endregion // Singleton





    #region public funcs

    public void LoadScene(SceneType sceneType)
    {
        switch (sceneType) {
            case SceneType.Start:
                UnityEngine.SceneManagement.SceneManager.LoadScene("StartScene");
                break;
            case SceneType.Dialog:
                UnityEngine.SceneManagement.SceneManager.LoadScene("DialogScene");
                GameDataManager.Instance.SceneName = "DialogScene";
                break;
            case SceneType.Room:
                UnityEngine.SceneManagement.SceneManager.LoadScene("RoomScene");
                GameDataManager.Instance.SceneName = "RoomScene";
                break;
            default:
                Debug.LogError("Unknown scene type: " + sceneType);
                break;
        }
    }

    #endregion // public funcs
}
