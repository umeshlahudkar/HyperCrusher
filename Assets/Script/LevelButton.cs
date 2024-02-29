using UnityEngine;
using TMPro;

public class LevelButton : MonoBehaviour
{
    private int levelNumber;
    [SerializeField] private TextMeshProUGUI levelNumberText;

    public void SetButton(int level)
    {
        levelNumber = level;
        levelNumberText.text = levelNumber.ToString();
    } 


    public void OnButtonClick()
    {
        GameManager.Instance.CurrentLevel = levelNumber;
        SceneLoader.Instance.LoadScene(levelNumber);
    }
}
