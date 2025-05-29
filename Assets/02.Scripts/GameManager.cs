using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton

    public static GameManager Instance { get; private set; }

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

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
    }

    #endregion // public funcs




    #region private funcs

    private void Start()
    {
        GameDataManager.Instance.LoadGame();
    }

    private void OnApplicationQuit()
    {
        GameDataManager.Instance.SaveGame();
    }

    #endregion // private funcs
}
