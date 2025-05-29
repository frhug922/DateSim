using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsManager : MonoBehaviour
{
    #region Singleton

    public static PlayerPrefsManager Instance { get; private set; }

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





    #region private fields

    private const string SceneNameKey = "SceneName";

    private const string ChapterKey = "Chapter";
    private const string DialogIDKey = "DialogID";

    private const string DayKey = "Day";
    private const string ApperanceKey = "Apperance";
    private const string HealthKey = "Health";
    private const string WealthKey = "Wealth";

    #endregion // private fields





    #region public funcs

    public void SaveData()
    {
        if (GameDataManager.Instance == null || GameDataManager.Instance.PlayerData == null) {
            Debug.LogError("GameDataManager.Instance or PlayerData is null.");
            return;
        }

        PlayerPrefs.SetString(SceneNameKey, GameDataManager.Instance.SceneName);

        PlayerPrefs.SetInt(ChapterKey, GameDataManager.Instance.PlayerData.Chapter);
        PlayerPrefs.SetInt(DialogIDKey, GameDataManager.Instance.PlayerData.DialogID);

        PlayerPrefs.SetInt(DayKey, GameDataManager.Instance.PlayerData.Day);
        PlayerPrefs.SetInt(ApperanceKey, GameDataManager.Instance.PlayerData.Apperance);
        PlayerPrefs.SetInt(HealthKey, GameDataManager.Instance.PlayerData.Health);
        PlayerPrefs.SetInt(WealthKey, GameDataManager.Instance.PlayerData.Wealth);

        PlayerPrefs.Save();
    }

    public void LoadData()
    {
        if (GameDataManager.Instance == null || GameDataManager.Instance.PlayerData == null) {
            Debug.LogError("GameDataManager.Instance or PlayerData is null.");
            return;
        }

        GameDataManager.Instance.PlayerData.Chapter = PlayerPrefs.GetInt(ChapterKey, 1);
        GameDataManager.Instance.PlayerData.DialogID = PlayerPrefs.GetInt(DialogIDKey, 1);

        GameDataManager.Instance.PlayerData.Day = PlayerPrefs.GetInt(DayKey, 1);
        GameDataManager.Instance.PlayerData.Apperance = PlayerPrefs.GetInt(ApperanceKey, 10);
        GameDataManager.Instance.PlayerData.Health = PlayerPrefs.GetInt(HealthKey, 10);
        GameDataManager.Instance.PlayerData.Wealth = PlayerPrefs.GetInt(WealthKey, 10);
    }

    #endregion // public funcs
}
