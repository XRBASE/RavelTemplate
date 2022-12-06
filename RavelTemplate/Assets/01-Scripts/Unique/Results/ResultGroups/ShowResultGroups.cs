using System.Collections.Generic;
using Base.Ravel.Questionnaires;
using UnityEngine;

public class ShowResultGroups : QuestionnaireFinishedEvent
{
    [SerializeField, Tooltip("Ordered list of group data visualizers.")] 
    private List<ResultGroupVisual> _visuals;
}
