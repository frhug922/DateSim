using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleUIController : MonoBehaviour
{
    #region public funcs

    public void OnClick_LoadButton()
    {
        PopupManager.Instance.ShowPopup("����� ������ �ҷ����ðڽ��ϱ�?", () => {
            GameManager.Instance.LoadGame();
        });
    }

    public void OnClick_NewGameButton()
    {
        PopupManager.Instance.ShowPopup("���ο� ������ �����Ͻðڽ��ϱ�?\n����� �����ʹ� ������ϴ�.", () => {
            GameManager.Instance.StartNewGame();
        });
    }

    public void OnClick_SettingsButton()
    {
        PopupManager.Instance.ShowSettingPopup();
    }

    public void OnClick_ExitButton()
    {
        PopupManager.Instance.ShowPopup("������ ������ �����Ͻǰǰ���?", () => {
            GameManager.Instance.ExitGame();
        });
    }

    #endregion // public funcs
}
