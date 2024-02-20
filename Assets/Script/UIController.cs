using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject finger;

    private void Start()
    {
        finger.SetActive(true);
    }

    public void OnSwipeFingerClick()
    {
        GameManager.instance.gameState = GameState.Playing;
        finger.SetActive(false);
    }
}
