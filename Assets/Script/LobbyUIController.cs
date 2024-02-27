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
        levelScreen.Activate(0.2f, MovementType.LeftToRight, () => mainMenuScreen.SetActive(false));

    }

    public void OnSettingButtonClick()
    {
        settingScreen.SetActive(true);
    }

    public void DisbleLevelScreen()
    {
        mainMenuScreen.SetActive(true);
        levelScreen.Deactivate(0.2f, MovementType.RightToLeft);
    }

    public void OnQuitButtonClick()
    {
        Application.Quit();
    }
}
