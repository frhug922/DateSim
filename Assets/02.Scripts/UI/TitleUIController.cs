using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleUIController : MonoBehaviour
{
    #region public funcs

    public void OnClick_LoadButton()
    {
        GameManager.Instance.LoadGame();
    }

    public void OnClick_NewGameButton()
    {
        GameManager.Instance.StartNewGame();
    }

    public void OnClick_SettingsButton()
    {

    }

    public void OnClick_ExitButton()
    {
        GameManager.Instance.ExitGame();
    }

    #endregion // public funcs
}
