using System.Collections;
using System.Collections.Generic;
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

    public void PlayPointAddSound()
    {
        pointsAudioSoure.Stop();
        pointsAudioSoure.clip = pointsAddClip;
        pointsAudioSoure.Play();
    }

    public void PlayPointDeductSound()
    {
        pointsAudioSoure.Stop();
        pointsAudioSoure.clip = pointsDeductClip;
        pointsAudioSoure.Play();
    }

    public void PlayItemConsumeSound()
    {
        consumeAudioSoure.Stop();
        consumeAudioSoure.clip = itemConsumeClip;
        consumeAudioSoure.Play();
    }

    public void PlayBlockBreakSound()
    {
        blockAudioSoure.Stop();
        blockAudioSoure.clip = blockBreakClip;
        blockAudioSoure.Play();
    }

    public void PlayBlockHitSound()
    {
        blockAudioSoure.Stop();
        blockAudioSoure.clip = blockhitClip;
        blockAudioSoure.Play();
    }

    public void PlayGameWinSound()
    {
        gameOverAudioSoure.Stop();
        gameOverAudioSoure.clip = gameWinClip;
        gameOverAudioSoure.Play();
    }

    public void PlayGameLoseSound()
    {
        gameOverAudioSoure.Stop();
        gameOverAudioSoure.clip = gameLoseClip;
        gameOverAudioSoure.Play();
    }
}
