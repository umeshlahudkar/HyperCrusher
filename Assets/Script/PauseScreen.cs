using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PauseScreen : MonoBehaviour
{
    [SerializeField] private RectTransform thisTransform;
    [SerializeField] private Image musicButtonImg;
    [SerializeField] private Image soundButtonImg;

    [SerializeField] private Sprite musicOnSprite;
    [SerializeField] private Sprite musicOffSprite;
    [SerializeField] private Sprite soundOnSprite;
    [SerializeField] private Sprite soundOffSprite;

    private void OnEnable()
    {
        SetScreen();
    }

    private void SetScreen()
    {
        thisTransform.localPosition = new Vector3(-Screen.width, 0, 0);
        thisTransform.DOLocalMove(Vector3.zero, 0.2f);

        SetMusicButtonImg();
        SetSoundButtonImg();
    }

    public void OnResumeButtonClick()
    {
        thisTransform.DOLocalMove(new Vector3(-Screen.width, 0, 0), 0.2f).OnComplete(()=>
        {
            gameObject.SetActive(false);
        });
    }

    public void OnHomeButtonClick()
    {
        SceneLoader.Instance.LoadScene(0);
    }

    public void OnMusicButtonClick()
    {
        bool status = AudioManager.Instance.IsBgMute ? false : true;
        AudioManager.Instance.ToggleMusicMute(status);
        SetMusicButtonImg();
    }

    public void OnSoundButtonClick()
    {
        bool status = AudioManager.Instance.IsSFXMute ? false : true;
        AudioManager.Instance.ToggleSoundMute(status);
        SetSoundButtonImg();
    }

    private void SetMusicButtonImg()
    {
        musicButtonImg.sprite = (AudioManager.Instance.IsBgMute) ? musicOffSprite : musicOnSprite;
    }

    private void SetSoundButtonImg()
    {
        soundButtonImg.sprite = (AudioManager.Instance.IsSFXMute) ? soundOffSprite : soundOnSprite;
    }

}
