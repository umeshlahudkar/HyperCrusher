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
        pauseScreen.SetActive(true);
    }

    public void UpdateProgressBar(float value)
    {
        progressBar.value = value;
    }
}
