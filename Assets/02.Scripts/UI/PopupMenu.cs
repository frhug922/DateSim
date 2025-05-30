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
        PopupManager.Instance.ShowPopup("홈으로 돌아가시겠습니까? \n 현재까지의 데이터가 저장됩니다.", () => {
            GameDataManager.Instance.SaveData();
            GameManager.Instance.LoadHomeScene();
        });
    }

    public void OnClick_Save()
    {
        PopupManager.Instance.ShowPopup("저장하시겠습니까?", () => {
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
