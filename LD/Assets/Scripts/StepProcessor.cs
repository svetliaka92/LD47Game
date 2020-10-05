using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StepProcessor : MonoBehaviour
{
    [SerializeField] StepUI _stepUI;
    [SerializeField] List<Step> steps;

    Dictionary<string, Step> stepsDict = new Dictionary<string, Step>(); // <stepId, stepChoices>
    Dictionary<string, int> stepAnswers = new Dictionary<string, int>(); // <stepId, answer index>

    string checkpointId;
    string currentStep;

    private void Awake()
    {
        LoadSteps();

        _stepUI.LoadStep("", "", new List<Answer>());
    }

    public void StartGame()
    {
        currentStep = steps[0].stepId;
        _stepUI.LoadStep(steps[0].stepId, steps[0].stepText, steps[0].stepAnswers);
    }

    public void EndGame()
    {
        _stepUI.LoadStep("", "", new List<Answer>());
    }

    private void LoadSteps()
    {
        foreach (Step step in steps)
        {
            string id = step.stepId;
            List<Answer> answers = step.stepAnswers;

            stepsDict.Add(id, step);
            stepAnswers.Add(id, -1);
        }

        checkpointId = steps[0].stepId;
    }

    public void ProcessAnswerInput(int inputNumber)
    {
        if (string.IsNullOrEmpty(currentStep)
            || inputNumber < 1 || inputNumber > 6)
            return;

        if (inputNumber > stepsDict[currentStep].stepAnswers.Count)
            return;

        ProcessAnswer(currentStep, (inputNumber - 1));
    }

    public void ProcessAnswer(string stepId, int answerIndex)
    {
        if (stepsDict.ContainsKey(stepId))
        {
            List<Answer> answers = stepsDict[stepId].stepAnswers;
            string nextStep = answers[answerIndex].nextStepId;

            LoadStep(nextStep);
        }
    }

    private void LoadStep(string stepId)
    {
        if (stepsDict.ContainsKey(stepId))
        {
            Step step = stepsDict[stepId];
            currentStep = step.stepId;

            _stepUI.LoadStep(step.stepId, step.stepText, step.stepAnswers);
        }
    }
}
