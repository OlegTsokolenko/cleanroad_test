using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [Header("UI Panel:")]
    [SerializeField] private GameObject _levelComplete;
    [SerializeField] private GameObject _levelRestart;
    [SerializeField] private GameObject _levelStart;
    [SerializeField] private PlayerVariable _speedPlayer;

    void Start()
    {
        _levelRestart.SetActive(false);
        _levelComplete.SetActive(false);
        _levelStart.SetActive(true);
    }

    public void CarMove()
    {
        _speedPlayer.valueSpeed = 15;

        _levelStart.SetActive(false);
    }

    public void LevelComplete()
    {
        _levelComplete.SetActive(true);
    }

    public void LevelRestart()
    {
        _levelRestart.SetActive(true);
    }

    private void OnEnable()
    {
        PlayerController.OnGameOver += LevelComplete;

        PlayerController.OnGameRestart += LevelRestart;
    }

    private void OnDisable()
    {
        PlayerController.OnGameOver -= LevelComplete;

        PlayerController.OnGameRestart -= LevelRestart;
    }
}
