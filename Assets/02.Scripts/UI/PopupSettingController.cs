using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopupSettingController : MonoBehaviour
{
    #region serialized field

    [SerializeField] private Slider _bgmSlider;
    [SerializeField] private Slider _textSpeedSlider;
    [SerializeField] private TMP_Text _testText;

    #endregion // serialized field




    #region private field

    private Tween _currTween;
    private string _log = "이것은 테스트용 대사입니다. 이 대사는 설정에서 조정한 속도로 표시됩니다. 대화 속도를 조절해 보세요!";

    #endregion // private field





    #region mono funcs

    private void Awake()
    {
        _textSpeedSlider.maxValue = Common._maxDialogSpeed;
        _textSpeedSlider.minValue = Common._minDialogSpeed;

        _bgmSlider.maxValue = Common._maxVolume;
        _bgmSlider.minValue = Common._minVolume;

        _textSpeedSlider.onValueChanged.AddListener(OnValueChanged_DialogSpeed);
        _bgmSlider.onValueChanged.AddListener(OnValueChanged_BGMVolume);
    }

    private void OnEnable()
    {
        Initialize();

        StartTest();
    }

    #endregion // mono funcs





    #region public funcs

    public void SetShow()
    {
        gameObject.SetActive(true);
    }

    public void OnClick_CloseButton()
    {
        SetHide();
    }

    public void SetHide()
    {
        gameObject.SetActive(false);
    }

    public void OnClick_Save()
    {
        GameDataManager.Instance.SettingData._volume = _bgmSlider.value;
        GameDataManager.Instance.SettingData._dialogSpeed = _textSpeedSlider.value;
        GameDataManager.Instance.SaveSettingData();
        SetHide();
    }

    #endregion // public funcs





    #region private funcs

    private void Initialize()
    {
        _bgmSlider.value = GameDataManager.Instance.SettingData._volume;
        _textSpeedSlider.value = GameDataManager.Instance.SettingData._dialogSpeed;
    }

    private void StartTest()
    {
        _currTween?.Kill();
        _testText.text = string.Empty;

        _currTween = _testText.DOText(_log, _log.Length * GameDataManager.Instance.SettingData._dialogSpeed)
                              .SetEase(Ease.Linear)
                              .SetLoops(-1, LoopType.Restart)
                              .OnStepComplete(() => _testText.text = string.Empty);
    }

    private void OnValueChanged_DialogSpeed(float value)
    {
        GameDataManager.Instance.SettingData._dialogSpeed = value;
        StartTest();
    }

    private void OnValueChanged_BGMVolume(float value)
    {
        GameDataManager.Instance.SettingData._volume = value;
    }

    #endregion // private funcs
}
