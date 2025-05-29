using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PopupOKCancel : MonoBehaviour
{
    [SerializeField] private TMP_Text _explaneText;
    [SerializeField] private TMP_Text _okText;
    [SerializeField] private TMP_Text _cancelText;

    private System.Action _okAction;
    private System.Action _cancelAction;


    public void Initialize(string explane, System.Action okCallback, System.Action cancelCallback, string okText, string calcelText)
    {
        _explaneText.text = explane;
        _okAction = okCallback;
        _cancelAction = cancelCallback;
        _okText.text = okText;
        _cancelText.text = calcelText;
    }

    public void SetShow()
    {
        gameObject.SetActive(true);
    }

    public void SetHide()
    {
        gameObject.SetActive(false);
    }

    public void OnClick_OK()
    {
        _okAction?.Invoke();
        SetHide();
    }

    public void OnClick_Cancel()
    {
        _cancelAction?.Invoke();
        SetHide();
    }
}
