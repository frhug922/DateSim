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

    private int chapter = 1;
    private int dialogID = 1;

    #endregion // private fields





    #region Properties

    public int Chapter { get { return chapter; } set { chapter = value; } }
    public int DialogID { get { return dialogID; } set { dialogID = value; } }

    #endregion // Properties
}