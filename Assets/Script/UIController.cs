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
}
