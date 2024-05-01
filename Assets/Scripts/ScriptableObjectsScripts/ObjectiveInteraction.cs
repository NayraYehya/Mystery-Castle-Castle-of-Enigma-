using Fungus;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Quests/Objective")]

public class ObjectiveInteraction : Objectives
{
    public override void CompleteObjective()
    {
        isCompleted = true;
    }
}
