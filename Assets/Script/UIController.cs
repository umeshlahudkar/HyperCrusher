using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : Singleton<UIController>
{
    [SerializeField] private GameObject finger;
    [SerializeField] private GameObject pauseScreen;

    [Header("Progress Bar")]
    [SerializeField] private Slider progressBar;
    [SerializeField] private TextMeshProUGUI levelNumberText;

    [Header("Game Over screen")]
    [SerializeField] private GameObject winScreen;
    [SerializeField] private GameObject loseScreen;

    [Header("Upper UI")]
    [SerializeField] private GameObject upperUI;

    public void SetUpLevelUI(int levelNumber)
    {
        finger.SetActive(true);
        upperUI.SetActive(false);
        levelNumberText.text = levelNumber.ToString();
    }

    public void OnSwipeFingerClick()
    {
        GameManager.Instance.StartGame();
    }

    public void ToggleSwipeFinger(bool status)
    {
        finger.SetActive(status);
    }

    public void EnableUpperUI()
    {
        upperUI.Activate(0.2f, MovementType.UpToDown);
    }

    public void DisableUpperUI()
    {
        upperUI.Deactivate(0.2f, MovementType.DownToUp);
    }

    public void OnPauseButtonClick()
    {
        GameManager.Instance.PauseGame();
        pauseScreen.Activate();
    }

    public void UpdateProgressBar(float value)
    {
        progressBar.value = value;
    }

    public void OpenGameWinScreen()
    {
        winScreen.Activate();
    }

    public void CloseGameWinScreen()
    {
        winScreen.Deactivate();
    }

    public void OpenGameLoseScreen()
    {
        loseScreen.Activate();
    }

    public void CloseGameLoseScreen()
    {
        loseScreen.Deactivate();
    }

    public void OnRetryButtonClick()
    {
        if(winScreen.activeSelf)
        {
            CloseGameWinScreen();
        }

        if(loseScreen.activeSelf)
        {
            CloseGameLoseScreen();
        }

        SceneLoader.Instance.LoadScene(SceneLoader.Instance.ActiveSceneIndex);
    }

    public void OnHomeButtonClick()
    {
        SceneLoader.Instance.LoadScene(0);
    }

    public void OnNextButtonClick()
    {
        if (winScreen.activeSelf)
        {
            CloseGameWinScreen();
        }

        if (loseScreen.activeSelf)
        {
            CloseGameLoseScreen();
        }

        int nextLevel = (SceneLoader.Instance.ActiveSceneIndex + 1);
        if(nextLevel > 2 || nextLevel == 0) { nextLevel = 1; }

        GameManager.Instance.CurrentLevel = nextLevel;
        SceneLoader.Instance.LoadScene(nextLevel);
    }
}
