using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuProcessor : MonoBehaviour
{
    [SerializeField] GameObject _mainMenu; // 0
    [SerializeField] GameObject _inGameMenu; // 1
    [SerializeField] GameObject _pauseMenu; // 2

    public GameObject currentMenu;

    public bool IsInPauseMenu => currentMenu == _pauseMenu;
    public bool IsInGameMenu => currentMenu == _inGameMenu;

    public void OnMenuButtonClicked(int menuNumber)
    {
        if (menuNumber == 0)
            OpenMainMenu();
        else if (menuNumber == 1)
            OpenInGameMenu();
        else if (menuNumber == 2)
            OpenPauseMenu();
    }

    internal void OpenMainMenu()
    {
        _pauseMenu.SetActive(false);
        _inGameMenu.SetActive(false);

        currentMenu = _mainMenu;
        Main.Instance.OnGameEnded();

        _mainMenu.SetActive(true);
    }

    public void OpenInGameMenu()
    {
        _pauseMenu.SetActive(false);
        _mainMenu.SetActive(false);

        currentMenu = _inGameMenu;
        Main.Instance.OnGameStarted();

        _inGameMenu.SetActive(true);
    }

    public void OpenPauseMenu()
    {
        _mainMenu.SetActive(false);
        _inGameMenu.SetActive(false);

        currentMenu = _pauseMenu;

        _pauseMenu.SetActive(true);
    }
}
