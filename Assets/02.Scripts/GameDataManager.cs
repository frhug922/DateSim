using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }

    #endregion // Singleton





    #region private fields

    private PlayerData playerData;

    #endregion // private fields





    #region Properties

    public PlayerData PlayerData { get { return playerData; } set { playerData = value; } }
    public string SceneName { get; set; } = "DialogScene";

    #endregion // Properties


    #region public funcs

    public void NewPlayerData()
    {
        playerData = new PlayerData {
            Chapter = 1,
            DialogID = 1,
            Day = 0,
            Apperance = 10,
            Health = 10,
            Wealth = 10,
        };
    }

    public void LoadGame()
    {
        PlayerPrefsManager.Instance.LoadData();
    }

    public void SaveGame()
    {
        PlayerPrefsManager.Instance.SaveData();
    }

    #endregion // public funcs
}


public class PlayerData
{
    public int Chapter { get; set; }
    public int DialogID { get; set; }

    // Ingame Data
    public int Day { get; set; }
    public int Apperance { get; set; }
    public int Health { get; set; }
    public int Wealth { get; set; }
}