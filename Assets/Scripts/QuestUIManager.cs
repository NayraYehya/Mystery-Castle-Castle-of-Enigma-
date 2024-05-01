using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestUIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI activeText;
    [SerializeField] private TextMeshProUGUI compText;
    [SerializeField] private GameObject GameOverPanel;

    public void UpdateUI(Quests quest, Objectives[] objectives)
    {
        
        if (quest != null)
        {
            activeText.text += "\n" + "<b>Quest:</b>" + quest.questName + "\nDescription: " + quest.questDescription + "\n";
        }
        else
        {
            Debug.LogWarning("Quest is null");
        }

        if (objectives != null)
        {
            foreach (Objectives objective in objectives)
            {
                activeText.text += "Objective: " + objective.description + "\n";
            }
        }
        else
        {
            Debug.LogWarning("Objective is null");
        }
    }

    public void UpdateCompleted(Quests quest, Objectives[] objectives)
    {
        if (quest != null)
        {
            compText.text += "\n" + "<b><color=green>Quest:</b></color>" + quest.questName + "\nDescription: " + quest.questDescription + "\n";
        }
        else
        {
            Debug.LogWarning("Quest is null");
        }

        if (objectives != null)
        {
            foreach (Objectives objective in objectives)
            {
                compText.text += "<b><color=green>Objective:</b></color>" + objective.description + "\n";
            }
        }
        else
        {
            Debug.LogWarning("Objective is null");
        }
    }


    public void check(List<Quests> quests)
    {
        activeText.text = "";
        foreach (Quests objective in quests)
        {
            UpdateUI(objective, objective.objectives);
        }
    }


    public void ShowGameOverPanel()
    {
        GameOverPanel.SetActive(true);
    }

    public void EndGame()
    {
        Application.Quit();
    }
}
