using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InagameUIManger : MonoBehaviour
{
    #region serialized fields  

    [SerializeField] private LogUIManager logUI;

    #endregion // serialized fields 


    #region private fields

    private int _chapter;
    private int _dialogID;
    private TDialogs _dialogTable;
    private TDialog _currLog;
    private TDialog _nextLog;

    #endregion // private fields


    #region mono funcs

    private void Start()
    {
        Initialize();

        StartLog();
    }

    #endregion // mono funcs





    #region private funcs

    public void Initialize()
    {
        _chapter = GameDataManager.Instance.Chapter;
        _dialogID = GameDataManager.Instance.DialogID;

        _dialogTable = TableManager.Instance.GetTable<TDialogs>(TableType.Dialog);

        _currLog = _dialogTable.Find(_chapter, _dialogID);
        _nextLog = _dialogTable.Find(_chapter, _currLog.NextID);

        logUI.Initialize(StartLog);
    }

    #endregion // private funcs



    #region private funcs

    private void StartLog()
    {
        logUI.SetLog(_currLog);
        FindNextLog();
    }

    private void FindNextLog()
    {
        _currLog = _nextLog;

        if (_currLog.IsEnd) { // 다음 씬으로 넘어가거나 뭐든 하기 TODO
            return;
        }
        _nextLog = _dialogTable.Find(_chapter, _currLog.NextID);
    }

    #endregion // private funcs



    //// test code

    //private void Start()
    //{
    //    logUI.SetLog("테스트 메시지를 보내보자. 테스트 메시지를 보내보자.테스트 메시지를 보내보자.테스트 메시지를 보내보자.테스트 메시지를 보내보자.테스트 메시지를 보내보자.테스트 메시지를 보내보자.테스트 메시지를 보내보자.테스트 메시지를 보내보자.테스트 메시지를 보내보자.", "김철수");
    //}
}
