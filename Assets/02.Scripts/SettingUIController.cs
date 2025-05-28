using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingUIController : UIBase
{
    #region public funcs

    public override void SetShow()
    {
        base.SetShow();
    }

    public override void SetHide()
    {
        base.SetHide();
    }

    public void OnClick_Close()
    {
        SetHide();
    }

    #endregion // public funcs
}
