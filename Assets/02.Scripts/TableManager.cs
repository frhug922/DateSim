using System;
using System.Collections.Generic;
using UnityEngine;

public class TableManager : MonoBehaviour
{
    #region Singleton

    public static TableManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this) {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadTables();
    }

    #endregion // Singleton





    #region private fields

    private Dictionary<TableType, TableBase> _tables = new();

    #endregion // private fields





    #region public fields

    public T GetTable<T>(TableType type) where T : TableBase
    {
        if (_tables.TryGetValue(type, out TableBase table)) {
            return table as T;
        }

        Debug.LogWarning($"[TableManager] 요청한 테이블이 없습니다: {type}");
        return null;
    }

    #endregion // public fields 





    #region private funcs

    private void LoadTables()
    {
        TDialogs dialogs = new TDialogs();
        dialogs.Load();
        _tables.Add(TableType.Dialog, dialogs);

        // Add other tables here as needed
    }

    #endregion // private funcs
}
