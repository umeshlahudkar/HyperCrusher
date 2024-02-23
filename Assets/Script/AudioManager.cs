using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    [Header("Audio Source")]
    [SerializeField] private AudioSource bgAudioSoure;
    [SerializeField] private AudioSource pointsAudioSoure;
    [SerializeField] private AudioSource consumeAudioSoure;
    [SerializeField] private AudioSource blockAudioSoure;
    [SerializeField] private AudioSource gameOverAudioSoure;

    [Header("Audio Clips")]
    [SerializeField] private AudioClip pointsDeductClip;
    [SerializeField] private AudioClip pointsAddClip;
    [SerializeField] private AudioClip itemConsumeClip;
    [SerializeField] private AudioClip blockBreakClip;
    [SerializeField] private AudioClip blockhitClip;
    [SerializeField] private AudioClip gameWinClip;
    [SerializeField] private AudioClip gameLoseClip;

    private float bgVolume = 0.5f;
    private float sfxVolume = 0.5f;

    private bool isBgMute = false;
    private bool isSfxMute = false;

    public float BgVolume { get { return bgVolume; } }
    public float SFXVolume { get { return sfxVolume; } }

    public bool IsBgMute { get { return isBgMute; } }
    public bool IsSFXMute { get { return isSfxMute; } }

    private void Start()
    {
        bgAudioSoure.mute = isBgMute;
        MuteSFXAudioSource(isSfxMute);

        bgAudioSoure.volume = bgVolume;
        UpdateSFXAudioSourceVolume(sfxVolume);
    }

    private void MuteSFXAudioSource(bool status)
    {
        pointsAudioSoure.mute = status;
        consumeAudioSoure.mute = status;
        blockAudioSoure.mute = status;
        gameOverAudioSoure.mute = status;
    }

    private void UpdateSFXAudioSourceVolume(float volume)
    {
        pointsAudioSoure.volume = volume;
        consumeAudioSoure.volume = volume;
        blockAudioSoure.volume = volume;
        gameOverAudioSoure.volume = volume;
    }

    public void UpdateBgVolume(float volume)
    {
        isBgMute = (volume <= 0);
        bgAudioSoure.mute = isBgMute;

        bgVolume = volume;
        bgVolume = Mathf.Clamp(bgVolume, 0, 1);
        bgAudioSoure.volume = bgVolume;
    }

    public void UpdateSFXVolume(float volume)
    {
        isSfxMute = (volume <= 0);
        MuteSFXAudioSource(isSfxMute);

        sfxVolume = volume;
        sfxVolume = Mathf.Clamp(sfxVolume, 0, 1);
        UpdateSFXAudioSourceVolume(sfxVolume);
    }

    public void PlayPointAddSound()
    {
        if(!isSfxMute)
        {
            pointsAudioSoure.Stop();
            pointsAudioSoure.clip = pointsAddClip;
            pointsAudioSoure.Play();
        }
    }

    public void PlayPointDeductSound()
    {
        if (!isSfxMute)
        {
            pointsAudioSoure.Stop();
            pointsAudioSoure.clip = pointsDeductClip;
            pointsAudioSoure.Play();
        }
    }

    public void PlayItemConsumeSound()
    {
        if (!isSfxMute)
        {
            consumeAudioSoure.Stop();
            consumeAudioSoure.clip = itemConsumeClip;
            consumeAudioSoure.Play();
        }
    }

    public void PlayBlockBreakSound()
    {
        if (!isSfxMute)
        {
            blockAudioSoure.Stop();
            blockAudioSoure.clip = blockBreakClip;
            blockAudioSoure.Play();
        }
    }

    public void PlayBlockHitSound()
    {
        if (!isSfxMute)
        {
            blockAudioSoure.Stop();
            blockAudioSoure.clip = blockhitClip;
            blockAudioSoure.Play();
        }
    }

    public void PlayGameWinSound()
    {
        if (!isSfxMute)
        {
            gameOverAudioSoure.Stop();
            gameOverAudioSoure.clip = gameWinClip;
            gameOverAudioSoure.Play();
        }
    }

    public void PlayGameLoseSound()
    {
        if (!isSfxMute)
        {
            gameOverAudioSoure.Stop();
            gameOverAudioSoure.clip = gameLoseClip;
            gameOverAudioSoure.Play();
        }
    }
}
