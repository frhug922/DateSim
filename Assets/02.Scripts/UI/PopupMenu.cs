using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupMenu : MonoBehaviour
{
    #region public funcs

    public void SetShow()
    {
        gameObject.SetActive(true);
    }

    public void SetHide()
    {
        gameObject.SetActive(false);
    }

    public void OnClick_Home()
    {
        PopupManager.Instance.ShowPopup("Ȩ���� ���ư��ðڽ��ϱ�? \n ��������� �����Ͱ� ����˴ϴ�.", () => {
            GameDataManager.Instance.SaveData();
            GameManager.Instance.LoadHomeScene();
        });
    }

    public void OnClick_Save()
    {
        PopupManager.Instance.ShowPopup("�����Ͻðڽ��ϱ�?", () => {
            GameDataManager.Instance.SaveData();
        });
    }

    public void OnClick_Setting()
    {
        PopupManager.Instance.ShowSettingPopup();
    }

    public void OnClick_Close()
    {
        SetHide();
    }

    #endregion // public funcs
}
