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

    }

    public void OnClick_NewGame()
    {
        SceneManager.Instance.LoadScene(SceneType.InGame);
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
