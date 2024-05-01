using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewObjective", menuName = "Quests/call")]

public class TalkWithNPC : Objectives
{
    public override void CompleteObjective()
    {
        isCompleted = true;
    }
}
