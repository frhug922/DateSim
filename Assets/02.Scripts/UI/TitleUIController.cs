using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleUIController : MonoBehaviour
{
    #region public funcs

    public void OnClick_LoadButton()
    {
        PopupManager.Instance.ShowPopup("저장된 게임을 불러오시겠습니까?", () => {
            GameManager.Instance.LoadGame();
        });
    }

    public void OnClick_NewGameButton()
    {
        PopupManager.Instance.ShowPopup("새로운 게임을 시작하시겠습니까?\n저장된 데이터는 사라집니다.", () => {
            GameManager.Instance.StartNewGame();
        });
    }

    public void OnClick_SettingsButton()
    {
        PopupManager.Instance.ShowSettingPopup();
    }

    public void OnClick_ExitButton()
    {
        PopupManager.Instance.ShowPopup("정말로 게임을 종료하실건가요?", () => {
            GameManager.Instance.ExitGame();
        });
    }

    #endregion // public funcs
}
