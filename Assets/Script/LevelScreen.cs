using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScreen : MonoBehaviour
{
    [SerializeField] private LobbyUIController lobbyUIController;
    [SerializeField] private LevelButton[] levelButtons;

    private void OnEnable()
    {
        SetLevelButtons();
    }

    private void SetLevelButtons()
    {
        for(int i = 0; i < levelButtons.Length; i++)
        {
            levelButtons[i].SetButton(i + 1);
        }
    }

    public void OnBackButtonClick()
    {
        lobbyUIController.ToggleLevelScreen(false);
    }
}
