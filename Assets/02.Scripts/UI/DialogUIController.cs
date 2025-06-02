using UnityEngine;

public class DialogUIController : MonoBehaviour
{
    #region serialized fields

    [SerializeField] private PopupDialog _popupDialog;
    [SerializeField] private PopupInputContoller _popupInputController;
    [SerializeField] private PopupChoice _popupChoice;
    [SerializeField] private PopupMenu _popupMenu;

    #endregion // serialized fields





    #region private fields

    private GameData _gameData;
    private TDialog _currDialog;

    #endregion // private fields





    #region // mono funcs

    private void Awake()
    {
        _gameData = GameDataManager.Instance.GameData;
        LoadCurrentDialog();
    }

    private void Start()
    {
        _popupDialog.Initialize(
            () => _popupMenu.SetShow(), // menu Callback
            () => { }, // auto Callback TODO
            () => { } // restart Callback TODO
            );

        ShowDialog();
    }

    #endregion // mono funcs





    #region private funcs

    private void LoadCurrentDialog()
    {
        var dialogTable = GameDataManager.Instance.GetTable<TDialogs>(TableType.Dialogs);
        _currDialog = dialogTable?.Find(_gameData._chapter, _gameData._dialogID);
    }

    private void ShowDialog()
    {
        if (_currDialog == null) {
            Debug.LogError("Current dialog is null");
            return;
        }

        switch ((DialogType)_currDialog.DialogType) {
            case DialogType.Input:
                _popupDialog.SetHide();
                _popupInputController.SetShow(() => {
                    SetNextDialog();
                    ShowDialog();
                });
                break;

            case DialogType.Normal:
                _popupDialog.SetShow(_currDialog, () => {
                    SetNextDialog();
                    ShowDialog();
                });
                break;

            case DialogType.Choice:
                _popupDialog.SetShow(_currDialog, () => {
                    _popupChoice.SetShow(_currDialog.ChoiceID, () => {
                        SetNextDialog();
                        ShowDialog();
                    });
                });
                break;

            case DialogType.End:
                _popupDialog.SetShow(_currDialog, () => {
                    GameManager.Instance.LoadRoomScene();
                });
                break;
        }
    }

    private void SetNextDialog()
    {
        var dialogTable = GameDataManager.Instance.GetTable<TDialogs>(TableType.Dialogs);
        _gameData._dialogID++;
        _currDialog = dialogTable?.Find(_gameData._chapter, _gameData._dialogID);
    }

    #endregion // private funcs
}
