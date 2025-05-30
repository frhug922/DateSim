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
    private Dictionary<TableType, TableBase> _tables = new();

    #endregion // private fields





    #region properties

    public GameData GameData { get { return _gameData; } private set { _gameData = value; } }
    public PlayerData PlayerData { get { return _playerData; } private set { _playerData = value; } }
    public SettingData SettingData { get { return _settingData; } private set { _settingData = value; } }

    #endregion // properties





    #region public funcs

    public T GetTable<T>(TableType type) where T : TableBase
    {
        if (_tables.TryGetValue(type, out var table)) {
            return table as T;
        }

        Debug.LogError($"Table of type {type} not found or incorrect type.");
        return null;
    }

    public void SaveData()
    {
        SaveGameData(GameData);
        SavePlayerData(PlayerData);
    }

    public void DeleteData()
    {
        PlayerPrefs.DeleteKey("GameData");
        PlayerPrefs.DeleteKey("PlayerData");
        PlayerPrefs.Save();
        GameData = new GameData();
        PlayerData = new PlayerData();
    }

    public void SaveGameData(GameData data)
    {
        string json = JsonUtility.ToJson(data);
        PlayerPrefs.SetString("GameData", json);
        PlayerPrefs.Save();
    }

    public void SaveGameData()
    {
        SaveGameData(GameData);
    }

    public void SavePlayerData(PlayerData data)
    {
        string json = JsonUtility.ToJson(data);
        PlayerPrefs.SetString("PlayerData", json);
        PlayerPrefs.Save();
    }

    public void SavePlayerData()
    {
        SavePlayerData(PlayerData);
    }

    public void SaveSettingData(SettingData data)
    {
        string json = JsonUtility.ToJson(data);
        PlayerPrefs.SetString("SettingData", json);
        PlayerPrefs.Save();
    }

    public void SaveSettingData()
    {
        SaveSettingData(SettingData);
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
        LoadTables();

        GameData = LoadGameData();
        PlayerData = LoadPlayerData();
        SettingData = LoadSettingData();
    }

    private void LoadTables()
    {
        _tables.Clear();

        // Add Tables
        _tables.Add(TableType.Dialogs, new TDialogs());

        foreach (var table in _tables.Values) {
            table.Load();
        }
    }

    #endregion // private funcs
}
