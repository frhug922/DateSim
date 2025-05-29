using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    #region type def

    private enum UIType
    {
        Setting = 0,
    }

    #endregion // type def





    #region serialized fields

    [SerializeField] private List<UIBase> uiMenu;

    #endregion // serialized fields





    #region public funcs

    public void OnClick_Load()
    {
        GameDataManager.Instance.LoadGame();
        if (GameDataManager.Instance.SceneName == "DialogScene") {
            SceneManager.Instance.LoadScene(SceneType.Dialog);
        }
        else {
            SceneManager.Instance.LoadScene(SceneType.Room);
        }
    }

    public void OnClick_NewGame()
    {
        GameDataManager.Instance.NewPlayerData();
        SceneManager.Instance.LoadScene(SceneType.Dialog);
    }

    public void OnClick_Setting()
    {
        uiMenu[(int)UIType.Setting].SetShow();
    }

    public void OnClick_ButtonExit()
    {
        GameManager.Instance.ExitGame();
    }

    #endregion // public funcs
}
