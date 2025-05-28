using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class TDialog
{
    public int Chapter;
    public int ID;
    public int NextID;
    public string Name;
    public string Dialog;
    public string BackgroundImage;
    public bool IsEnd;
}

[Serializable]
public class TDialogs : TableBase
{
    public List<TDialog> Dialogs = new();

    public override void Load()
    {
        TextAsset jsonFile = Resources.Load<TextAsset>("Tables/t_Dialogs");
        if (jsonFile == null) {
            Debug.LogError($"[TDialogs] JSON 파일을 찾을 수 없습니다: Tables/t_Dialogs");
            return;
        }

        TDialogs loaded = JsonUtility.FromJson<TDialogs>(jsonFile.text);
        if (loaded == null || loaded.Dialogs == null) {
            Debug.LogError("[TDialogs] JSON 파싱 실패 또는 Dialogs가 비어 있습니다.");
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
