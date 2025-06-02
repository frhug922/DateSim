using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class TDialog
{
    public int Chapter;
    public int ID;
    public int DialogType;
    public string Name;
    public string Dialog;
    public string BackgroundImage;
    public int ChoiceID;
}

[Serializable]
public class TDialogs : TableBase
{
    public List<TDialog> Dialogs = new();

    public override void Load()
    {
        TextAsset jsonFile = Resources.Load<TextAsset>("Tables/t_Dialogs");
        if (jsonFile == null) {
            return;
        }

        TDialogs loaded = JsonUtility.FromJson<TDialogs>(jsonFile.text);
        if (loaded == null || loaded.Dialogs == null) {
            return;
        }

        Dialogs = loaded.Dialogs;
    }

    public TDialog Find(int chapter, int id)
    {
        foreach (var dialog in Dialogs) {
            if (dialog.Chapter == chapter && dialog.ID == id) {
                return dialog;
            }
        }

        return null;
    }
}