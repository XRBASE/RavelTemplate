using Base.Ravel.Questionnaires;
using UnityEngine;

/// <summary>
/// Listens to object question and spawns chosen object when question has been answered.
/// </summary>
public class SpawnPickedObj : QuestionEvent<ObjectAnswer>
{
    [SerializeField, Tooltip("This is the transform under which the object is spawned (zero local position and rotation, but original scale).")] 
    private Transform _objParent;
}
