using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public static QuestManager instance;

    [SerializeField] private List<Quests> activeQuests = new List<Quests>();
    [SerializeField] private List<Quests> completedQuests = new List<Quests>();
    [SerializeField] private Quests MainQuest;
    [SerializeField] private GameObject key;

    [SerializeField] private QuestUIManager uiManager;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

    }

    public void AddQuest(Quests quest)
    {
        activeQuests.Add(quest);
        uiManager.check(activeQuests);

        if (quest != null)
        {
            quest.QuestCompleted = false;
            foreach (Objectives objective in quest.objectives)
            {
                objective.isCompleted = false;
            }
        }
    }

    public void CheckQuestCompletion(Quests quest)
    {
        if (endQuest(quest))
        {
            Debug.Log("Quest completed: " + quest.questName);
            quest.QuestCompleted = true;

            uiManager.UpdateCompleted(quest, quest.objectives);
            completedQuests.Add(quest);
            activeQuests.Remove(quest);
            uiManager.check(activeQuests);

            if (endGame())
            {
                Debug.Log("Game completed ");
                key.SetActive(true);
            }
        }
    }

    public bool endQuest(Quests quest)
    {
        foreach (Objectives objective in quest.objectives)
        {
            if (!objective.isCompleted)
            {
                Debug.Log("Not Completed");
                return false;
            }
        }
        return true;
    }

    public bool endGame()
    {
        foreach (Quests quest in activeQuests)
        {
            if (!quest.QuestCompleted)
            {
                Debug.Log("Quests Not Completed");
                return false;
            }
        }
        Debug.Log("Quests Done!");
        if (completedQuests.Count >= 2)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    public void Interact(Objectives obj)
    {
        obj.CompleteObjective();
    }

}
