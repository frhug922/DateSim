#region Definations

public enum TableType
{
    Dialogs,
}

public enum DialogType
{
    Normal = 1,
    Input = 2,
    Choice = 3,
    End = 4,
}

#endregion Definations





#region Common class

public static class Common
{
    public const float _maxDialogSpeed = 0.2f;
    public const float _minDialogSpeed = 0.02f;

    public const float _minVolume = 0f;
    public const float _maxVolume = 1f;
}

#endregion // Common class