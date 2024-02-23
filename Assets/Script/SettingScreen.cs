using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SettingScreen : MonoBehaviour
{
    [Header("Music")]
    [SerializeField] private Slider musicVolumeSlider;

    [Header("SFX")]
    [SerializeField] private Slider soundVolumeSlider;

    [Space(10)]
    [SerializeField] private RectTransform settingPanel;

    private Vector3 initialPosition;

    private void Awake()
    {
        initialPosition = settingPanel.position;
    }

    private void OnEnable()
    {
        settingPanel.position = new Vector3(settingPanel.position.x, (Screen.height + (settingPanel.rect.height / 2)), 0);
        settingPanel.DOMove(initialPosition, 0.2f);

        musicVolumeSlider.value = AudioManager.Instance.BgVolume;
        soundVolumeSlider.value = AudioManager.Instance.SFXVolume;
    }

    public void OnMusicSliderValueChanged()
    {
        AudioManager.Instance.UpdateBgVolume(musicVolumeSlider.value);
    }

    public void OnSoundSliderValueChanged()
    {
        AudioManager.Instance.UpdateSFXVolume(soundVolumeSlider.value);
    }

    public void OnCloseButtonClick()
    {
        settingPanel.DOMove(new Vector3(settingPanel.position.x, (Screen.height + (settingPanel.rect.height / 2)), 0), 0.2f).OnComplete(() =>
        {
            settingPanel.position = initialPosition;
            gameObject.SetActive(false);
        });
    }
}
