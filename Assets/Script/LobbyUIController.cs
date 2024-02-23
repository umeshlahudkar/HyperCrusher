using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyUIController : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuScreen;
    [SerializeField] private GameObject levelScreen;
    [SerializeField] private GameObject settingScreen;

    public void OnPlayButtonClick()
    {
        ToggleLevelScreen(true);
    }

    public void OnSettingButtonClick()
    {
        settingScreen.SetActive(true);
    }

    public void ToggleLevelScreen(bool status)
    {
        mainMenuScreen.SetActive(!status);
        levelScreen.SetActive(status);
    }

    public void OnQuitButtonClick()
    {
        Application.Quit();
    }
}
