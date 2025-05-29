using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        GameDataManager.Instance.SaveData();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void StartNewGame()
    {
        GameDataManager.Instance.DeleteData();
        GameDataManager.Instance.SaveData();
        SceneManager.LoadScene("DialogScene");
    }

    public void LoadGame()
    {
        if (GameDataManager.Instance.GameData._sceneName == "DialogScene") {
            SceneManager.LoadScene("DialogScene");
        }
        else {
            SceneManager.LoadScene("RoomScene");
        }
    }

    #endregion // public funcs
}
