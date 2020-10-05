using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AnswerButton : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;

    public void SetData(string answer)
    {
        text.text = answer;
    }
}
