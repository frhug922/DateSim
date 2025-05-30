using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupManager : MonoBehaviour
{
    #region Singleton

    public static PopupManager Instance { get; private set; }

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





    #region serialized fields

    [SerializeField] private PopupOKCancel _popupPrefab;
    [SerializeField] private PopupSettingController _popupSettingPrefab;

    #endregion // serialized fields





    #region public funcs

    public void ShowPopup(string explane, System.Action okCallback = null, System.Action cancelCallback = null, string okText = "확인", string cancelText = "취소")
    {
        _popupPrefab.Initialize(explane, okCallback, cancelCallback, okText, cancelText);
        _popupPrefab.SetShow();
    }

    public void ShowSettingPopup()
    {
        _popupSettingPrefab.SetShow();
    }

    #endregion // public funcs
}
