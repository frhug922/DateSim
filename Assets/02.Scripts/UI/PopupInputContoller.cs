using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PopupInputContoller : MonoBehaviour
{
    [SerializeField] private TMP_InputField _inputField;


    private System.Action _onCompleteCallback;

    public void SetShow(System.Action onComplete)
    {
        _onCompleteCallback = onComplete;

        gameObject.SetActive(true);
    }

    public void SetHide()
    {
        gameObject.SetActive(false);
        _inputField.text = string.Empty;
    }

    public void OnClick_OKButton()
    {
        if (_inputField.text.Length > 0) {
            Debug.Log("Input: " + _inputField.text);
            GameDataManager.Instance.PlayerData._playerName = _inputField.text;
            GameDataManager.Instance.SavePlayerData();
            SetHide();
            _onCompleteCallback?.Invoke();
        }
        else {
            Debug.LogWarning("Input field is empty!");
        }
    }
}
