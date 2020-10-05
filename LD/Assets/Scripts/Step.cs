using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Step", menuName = "Step", order = 0)]
public class Step : ScriptableObject
{
    public string stepId;
    [TextArea] public string stepText;
    public List<Answer> stepAnswers;
}
