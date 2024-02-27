using UnityEngine;
using UnityEngine.UI;

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
        SetMusicButtonImg();
        SetSoundButtonImg();
    }

    public void OnResumeButtonClick()
    {
        gameObject.Deactivate(0.2f, MovementType.RightToLeft, ()=> 
        {
            GameManager.Instance.UnPauseGame();
        });
    }

    public void OnHomeButtonClick()
    {
        GameManager.Instance.ResetGame();
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
