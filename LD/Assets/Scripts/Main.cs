using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    private static Main _instance;
    public static Main Instance => _instance;

    [SerializeField] StepProcessor _stepProcessor;
    [SerializeField] MenuProcessor _menuProcessor;

    bool _isGamePlaying;

    private void Awake()
    {
        _instance = this;

        _isGamePlaying = false;
    }

    private void Start()
    {
        _menuProcessor.OpenMainMenu();
    }

    public void OnGameStarted()
    {
        _stepProcessor.StartGame();

        _isGamePlaying = true;
    }

    public void OnGameEnded()
    {
        _stepProcessor.EndGame();

        _isGamePlaying = false;
    }

    private void Update()
    {
        ProcessInputNumbers();
        ProcessMenuInput();
    }

    private void ProcessMenuInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_menuProcessor.IsInGameMenu)
                _menuProcessor.OnMenuButtonClicked(2);
            else if (_menuProcessor.IsInPauseMenu)
                _menuProcessor.OnMenuButtonClicked(1);
        }
    }

    private void ProcessInputNumbers()
    {
        if (!_isGamePlaying)
            return;

        if (Input.GetKeyDown(KeyCode.Alpha1))
            _stepProcessor.ProcessAnswerInput(1);
        else if (Input.GetKeyDown(KeyCode.Alpha2))
            _stepProcessor.ProcessAnswerInput(2);
        else if (Input.GetKeyDown(KeyCode.Alpha3))
            _stepProcessor.ProcessAnswerInput(3);
        else if (Input.GetKeyDown(KeyCode.Alpha4))
            _stepProcessor.ProcessAnswerInput(4);
        else if (Input.GetKeyDown(KeyCode.Alpha5))
            _stepProcessor.ProcessAnswerInput(5);
        else if (Input.GetKeyDown(KeyCode.Alpha6))
            _stepProcessor.ProcessAnswerInput(6);
    }
}
