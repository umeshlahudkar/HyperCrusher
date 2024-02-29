using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private GameState gameState = GameState.waiting;
    private PlayerController playerController;

    private bool hasClickedOnFinger = false;

    public GameState GameState { get { return gameState; } }

    private void OnEnable()
    {
        SceneLoader.OnSceneLoad += OnSceneLoad;
    }

    private void OnSceneLoad()
    {
        UIController.Instance.SetUpLevelUI(1);
    }

    public void StartGame()
    {
        hasClickedOnFinger = true;
        SetGameState(GameState.Playing);
        UIController.Instance.ToggleSwipeFinger(false);
        UIController.Instance.EnableUpperUI();
    }

    private void SetPlayerController()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    public void SetGameState(GameState newState)
    {
        gameState = newState;
    }

    public void PauseGame()
    {
        if(playerController == null) { SetPlayerController(); }
        gameState = GameState.Paused;
        playerController.OnGamePause();
    }

    public void UnPauseGame()
    {
        if (playerController == null) { SetPlayerController(); }
        playerController.OnGameUnpause();
        SetGameState( hasClickedOnFinger ? GameState.Playing : GameState.waiting);
    }

    public void OnGameWin()
    {
        UIController.Instance.DisableUpperUI();
        AudioManager.Instance.PlayGameWinSound();
        SetGameState(GameState.Ending);
        UIController.Instance.OpenGameWinScreen();
    }

    public void OnGameLose()
    {
        UIController.Instance.DisableUpperUI();
        AudioManager.Instance.PlayGameLoseSound();
        SetGameState(GameState.Ending);
        UIController.Instance.OpenGameLoseScreen();
    }

    public void ResetGame()
    {
        SetGameState(GameState.waiting);
        hasClickedOnFinger = false;
    }

    private void OnDisable()
    {
        SceneLoader.OnSceneLoad -= OnSceneLoad;
    }
}
