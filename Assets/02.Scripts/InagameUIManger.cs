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

        if (_currLog.IsEnd) { // ���� ������ �Ѿ�ų� ���� �ϱ� TODO
            return;
        }
        _nextLog = _dialogTable.Find(_chapter, _currLog.NextID);
    }

    #endregion // private funcs



    //// test code

    //private void Start()
    //{
    //    logUI.SetLog("�׽�Ʈ �޽����� ��������. �׽�Ʈ �޽����� ��������.�׽�Ʈ �޽����� ��������.�׽�Ʈ �޽����� ��������.�׽�Ʈ �޽����� ��������.�׽�Ʈ �޽����� ��������.�׽�Ʈ �޽����� ��������.�׽�Ʈ �޽����� ��������.�׽�Ʈ �޽����� ��������.�׽�Ʈ �޽����� ��������.", "��ö��");
    //}
}
