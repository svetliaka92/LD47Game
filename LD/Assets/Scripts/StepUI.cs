using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class StepUI : MonoBehaviour
{
    [SerializeField] StepProcessor _stepProcessor;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] List<AnswerButton> buttons;
    [SerializeField] Image textBackground;
    [SerializeField] Image buttonsBackground;

    string currentStepId = "";

    public void OnAnswerClicked(int answerIndex)
    {
        _stepProcessor.ProcessAnswer(currentStepId, answerIndex);
    }

    public void LoadStep(string stepId, string stepText, List<Answer> answers)
    {
        text.text = "";
        foreach (AnswerButton go in buttons)
            go.gameObject.SetActive(false);

        if (string.IsNullOrEmpty(stepId)
            || string.IsNullOrEmpty(stepText)
            || answers == null || answers.Count <= 0)
        {
            EnableBackgrounds(false);
            return;
        }

        ToggleBackgrounds(true);

        currentStepId = stepId;

        text.text = stepText;

        for (int i = 0; i < answers.Count; ++i)
        {
            buttons[i].SetData(answers[i].answerText);
            buttons[i].gameObject.SetActive(true);
        }
    }

    private void ToggleBackgrounds(bool state)
    {
        textBackground.gameObject.SetActive(state);
        buttonsBackground.gameObject.SetActive(state);
    }
}
