using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    #region Singleton

    public static SoundManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this) {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    #endregion // Singleton





    #region serialized fields

    [SerializeField] private AudioSource _bgmSource;

    #endregion // serialized fields





    #region mono funcs

    private void Start()
    {
        _bgmSource.volume = GameDataManager.Instance.SettingData._volume;

        _bgmSource.Play();
    }

    #endregion // mono funcs



    #region public funcs

    public void SetBGMVolume(float volume)
    {
        _bgmSource.volume = Mathf.Clamp(volume, Common._minVolume, Common._maxVolume);
    }

    #endregion // public funcs
}
