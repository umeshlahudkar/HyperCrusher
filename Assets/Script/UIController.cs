using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    private void Awake()
    {
        instance = this;
    }

    [SerializeField] private GameObject finger;

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
        GameManager.instance.gameState = GameState.Playing;
        finger.SetActive(false);
    }

    public void UpdateProgressBar(float value)
    {
        progressBar.value = value;
    }
}
