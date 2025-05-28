using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LogUIManager : UIBase
{
    #region private fields

    private Tween currentTween;
    private float typingSpeed = 0.05f; // 초당 글자 수, 0.05초에 한 글자 출력
    private System.Action _callback;

    #endregion // private fields




    #region serialized fields

    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private TMP_Text nameText;

    #endregion // serialized fields





    #region public funcs

    public void Initialize(System.Action callback)
    {
        _callback = callback;
    }

    public void SetLog(string log, string name = null)
    {
        ShowName(name);
        ShowLog(log);
    }

    public void SetLog(TDialog tDialog)
    {
        ShowName(tDialog.Name);
        ShowLog(tDialog.Dialog);
    }

    public void OnClick_Log()
    {
        if (currentTween.IsPlaying()) {
            ShowAllImmediately();
        }
        else {
            _callback();
        }
    }

    #endregion // public funcs


    #region private funcs

    private void ShowName(string name)
    {
        if (nameText != null) {
            nameText.text = "|" + name;
        }
        else {
            nameText.text = string.Empty;
        }
    }

    private void ShowLog(string log)
    {
        currentTween?.Kill();

        dialogueText.text = "";
        currentTween = dialogueText.DOText(log, log.Length * typingSpeed)
                                   .SetEase(Ease.Linear);
    }

    private void ShowAllImmediately()
    {
        currentTween?.Complete(); // 즉시 전체 텍스트 표시
    }

    #endregion // private funcs
}
