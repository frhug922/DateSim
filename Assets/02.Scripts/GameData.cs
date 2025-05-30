using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData
{
    public string _sceneName;

    public int _chapter;
    public int _dialogID;

    public GameData()
    {
        _sceneName = "DialogScene";
        _chapter = 1;
        _dialogID = 1;
    }

    public GameData(string sceneName, int chapter, int dialogID)
    {
        _sceneName = sceneName;
        _chapter = chapter;
        _dialogID = dialogID;
    }
}

public class PlayerData
{
    public string _playerName;
    public int _playerInt;
    public int _playerAppearance;
    public int _playerWealth;
    public int _day;

    public PlayerData()
    {
        _playerName = "playerName";
        _playerInt = 10;
        _playerAppearance = 10;
        _playerWealth = 10;
        _day = 1;
    }

    public PlayerData(string playerName, int playerInt, int playerAppearance, int playerWealth, int day)
    {
        _playerName = playerName;
        _playerInt = playerInt;
        _playerAppearance = playerAppearance;
        _playerWealth = playerWealth;
        _day = day;
    }
}

public class SettingData
{
    public float _volume;
    public float _dialogSpeed;

    public SettingData()
    {
        _volume = 1f;
        _dialogSpeed = 0.1f;
    }

    public SettingData(float volume, float dialogSpeed)
    {
        _volume = volume;
        _dialogSpeed = dialogSpeed;
    }
}
