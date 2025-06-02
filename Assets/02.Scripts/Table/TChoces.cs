using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

[Serializable]
public class TChoice
{
    public int ID;
    public string Choice1;
    public string Choice2;
}

[Serializable]
public class TChoices : TableBase
{
    public List<TChoice> Choices = new();

    public override void Load()
    {
        TextAsset jsonFile = Resources.Load<TextAsset>("Tables/t_Choices");
        if (jsonFile == null) {
            return;
        }

        TChoices loaded = JsonUtility.FromJson<TChoices>(jsonFile.text);
        if (loaded == null || loaded.Choices == null) {
            return;
        }

        Choices = loaded.Choices;
    }

    public TChoice Find(int id)
    {
        foreach (var choice in Choices) {
            if (choice.ID == id) {
                return choice;
            }
        }

        return null;
    }
}
