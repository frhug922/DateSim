using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PopupInputContoller : MonoBehaviour
{
    [SerializeField] private TMP_InputField _inputField;


    public void OnClick_OKButton()
    {
        if (_inputField.text.Length > 0) {
            Debug.Log("Input: " + _inputField.text);
            // Here you can add logic to handle the input, e.g., save it or process it.
        }
        else {
            Debug.LogWarning("Input field is empty!");
        }
    }
}
