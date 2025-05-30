using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopupDialog : MonoBehaviour
{
    #region serialized fields

    [SerializeField] private TMP_Text _dialogText;
    [SerializeField] private TMP_Text _nameText;
    [SerializeField] private Image _characterImage;

    #endregion // serialized fields





    #region private fields

    private System.Action _onCompleteCallback;
    private System.Action _menuCallback;
    private System.Action _autoCallback;
    private System.Action _restartCallback;
    private Tween _currentTween;

    #endregion // private fields





    #region public funcs

    public void Initialize(System.Action menuCallback, System.Action autoCallback, System.Action restartCallback)
    {
        _menuCallback = menuCallback;
        _autoCallback = autoCallback;
        _restartCallback = restartCallback;
    }

    public void SetShow(TDialog dialog, System.Action onComplete)
    {
        if (dialog == null) {
            Debug.LogError("Dialog is null");
            return;
        }

        _onCompleteCallback = onComplete;
        gameObject.SetActive(true);

        ShowName(dialog.Name);
        ShowLog(dialog.Dialog);
    }

    public void SetHide()
    {
        gameObject.SetActive(false);
    }

    public void OnClick_Dialog()
    {
        if (_currentTween != null && _currentTween.IsPlaying()) {
            _currentTween.Complete();
        }
        else {
            _onCompleteCallback?.Invoke();
        }
    }

    public void OnClick_Menu()
    {
        _menuCallback?.Invoke();
    }

    public void OnClick_ReStart()
    {
        _restartCallback?.Invoke();
    }

    public void OnClick_Auto()
    {
        _autoCallback?.Invoke();
    }

    #endregion // public funcs





    #region private funcs

    private void ShowName(string name)
    {
        _nameText.text = (name == "Player")
            ? GameDataManager.Instance.PlayerData._playerName
            : name;
    }

    private void ShowLog(string log)
    {
        _currentTween?.Kill();
        _dialogText.text = "";
        _currentTween = _dialogText
            .DOText(log, log.Length * GameDataManager.Instance.SettingData._dialogSpeed)
            .SetEase(Ease.Linear);
    }

    #endregion // private funcs
}
