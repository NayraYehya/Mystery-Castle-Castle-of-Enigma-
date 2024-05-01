using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SocialPlatforms.Impl;

public class Objectives : ScriptableObject
{
    public string description;
    public bool isCompleted;
    
    public virtual void CompleteObjective()
    {
    }

}
