using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameDataManager : MonoBehaviour
{
    #region Singleton

    public static GameDataManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this) {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        Initialize();
    }

    #endregion // Singleton





    #region private fields

    private GameData _gameData;
    private PlayerData _playerData;
    private SettingData _settingData;

    #endregion // private fields





    #region properties

    public GameData GameData { get { return _gameData; } private set { _gameData = value; } }
    public PlayerData PlayerData { get { return _playerData; } private set { _playerData = value; } }
    public SettingData SettingData { get { return _settingData; } private set { _settingData = value; } }

    #endregion // properties





    #region public funcs

    public void SaveAll()
    {
        SaveGameData(GameData);
        SavePlayerData(PlayerData);
        SaveSettingData(SettingData);
    }

    public void SaveGameData(GameData data)
    {
        string json = JsonUtility.ToJson(data);
        PlayerPrefs.SetString("GameData", json);
        PlayerPrefs.Save();
    }

    public void SavePlayerData(PlayerData data)
    {
        string json = JsonUtility.ToJson(data);
        PlayerPrefs.SetString("PlayerData", json);
        PlayerPrefs.Save();
    }

    public void SaveSettingData(SettingData data)
    {
        string json = JsonUtility.ToJson(data);
        PlayerPrefs.SetString("SettingData", json);
        PlayerPrefs.Save();
    }

    public GameData LoadGameData()
    {
        if (!PlayerPrefs.HasKey("GameData"))
            return new GameData();

        string json = PlayerPrefs.GetString("GameData");
        return JsonUtility.FromJson<GameData>(json);
    }

    public PlayerData LoadPlayerData()
    {
        if (!PlayerPrefs.HasKey("PlayerData"))
            return new PlayerData();
        string json = PlayerPrefs.GetString("PlayerData");
        return JsonUtility.FromJson<PlayerData>(json);
    }

    public SettingData LoadSettingData()
    {
        if (!PlayerPrefs.HasKey("SettingData"))
            return new SettingData();
        string json = PlayerPrefs.GetString("SettingData");
        return JsonUtility.FromJson<SettingData>(json);
    }

    #endregion // public funcs





    #region private funcs

    private void Initialize()
    {
        GameData = LoadGameData();
        PlayerData = LoadPlayerData();
        SettingData = LoadSettingData();
    }

    #endregion // private funcs
}
