using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Quests/Quest")]
public class Quests : ScriptableObject 
{
    public string questName;
    public string questDescription;
    public Objectives[] objectives;
    public bool QuestCompleted;
}