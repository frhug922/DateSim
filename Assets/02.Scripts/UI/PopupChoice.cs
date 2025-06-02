using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PopupChoice : MonoBehaviour
{
    #region serialized fields

    [SerializeField] private TMP_Text _choiceText1;
    [SerializeField] private TMP_Text _choiceText2;
    //[SerializeField] private TMP_Text _choiceText3;
    //[SerializeField] private TMP_Text _choiceText4;

    #endregion // serialized fields





    #region private fields

    private TChoice _choice;
    private System.Action _onComplete;

    #endregion // private fields





    #region public funcs

    public void SetShow(int choiceID, System.Action onCompleteAction)
    {
        _onComplete = onCompleteAction;

        var choiceTable = GameDataManager.Instance.GetTable<TChoices>(TableType.Choices);
        _choice = choiceTable?.Find(choiceID);

        _choiceText1.text = _choice?.Choice1 ?? string.Empty;
        _choiceText2.text = _choice?.Choice2 ?? string.Empty;

        gameObject.SetActive(true);
    }

    public void SetHide()
    {
        gameObject.SetActive(false);
    }

    public void OnClick_Choice(int choiceIndex)
    {
        _onComplete?.Invoke();

        // TODO: Handle choice selection logic  

        SetHide();
    }

    #endregion // public funcs
}
