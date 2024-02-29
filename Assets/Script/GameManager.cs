using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private GameState gameState = GameState.waiting;
    private PlayerController playerController;

    private bool hasClickedOnFinger = false;
    private int currentLevel = 0;

    public int CurrentLevel 
    { 
        get { return currentLevel; } 
        set { currentLevel = value; }
    }

    public GameState GameState { get { return gameState; } }

    private void OnEnable()
    {
        SceneLoader.OnSceneLoad += OnSceneLoad;
    }

    private void OnSceneLoad()
    {
        if(SceneLoader.Instance.ActiveSceneIndex != 0)
        {
            UIController.Instance.SetUpLevelUI(currentLevel);
        }
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
        Invoke(nameof(OpenGameWinScreen), 3f);
    }

    public void OnGameLose()
    {
        UIController.Instance.DisableUpperUI();
        AudioManager.Instance.PlayGameLoseSound();
        SetGameState(GameState.Ending);
        Invoke(nameof(OpenGameLoseScreen), 3f);
    }

    private void OpenGameWinScreen()
    {
        UIController.Instance.OpenGameWinScreen();
    }

    private void OpenGameLoseScreen()
    {
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
