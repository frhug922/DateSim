using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleUIController : MonoBehaviour
{
    #region public funcs

    public void OnClick_LoadButton()
    {

    }

    public void OnClick_NewGameButton()
    {

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
