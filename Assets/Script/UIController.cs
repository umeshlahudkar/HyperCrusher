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

    private void Start()
    {
        finger.SetActive(true);
        levelNumberText.text = 1.ToString();
    }

    public void OnSwipeFingerClick()
    {
        GameManager.Instance.StartGame();
    }

    public void ToggleSwipeFinger(bool status)
    {
        finger.SetActive(status);
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

    public void ToggleGameWinScreen(bool status)
    {
        winScreen.SetActive(status);
    }

    public void ToggleGameLoseScreen(bool status)
    {
        loseScreen.SetActive(status);
    }
}
