using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Quests))]
public class QuestEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Quests quest = (Quests)target;

        if (quest != null)
        {
            EditorGUILayout.LabelField("Quest Name", quest.questName);
            EditorGUILayout.Space();

            //show objective data
            EditorGUILayout.LabelField("Objectives");

            if (quest.objectives.Length > 0)
            {
                for (int i = 0; i < quest.objectives.Length; i++)
                {
                    Objectives objective = quest.objectives[i];

                    EditorGUILayout.BeginVertical();

                    // Display the scriptable object reference
                    EditorGUILayout.ObjectField("Scriptable Object", objective, typeof(Objectives), false);

                    objective.description = EditorGUILayout.TextField("Description", objective.description);
                    //objective.isCompleted = EditorGUILayout.("Score Value", objective.isCompleted);

                    //remove this objective
                    if (GUILayout.Button("Remove Objective"))
                    {
                        ArrayUtility.RemoveAt(ref quest.objectives, i);
                        AssetDatabase.RemoveObjectFromAsset(objective);
                        AssetDatabase.SaveAssets();
                        Repaint(); //update the GUI
                        return;
                    }

                    EditorGUILayout.EndVertical();
                }
            }

            //to add new objective
            if (GUILayout.Button("Add Objective"))
            {
                Objectives newObjective = CreateInstance<Objectives>();

                EditorGUILayout.BeginHorizontal();
                newObjective.description = EditorGUILayout.TextField("Description", newObjective.description);
                EditorGUILayout.EndHorizontal();

                ArrayUtility.Add(ref quest.objectives, newObjective);

                AssetDatabase.AddObjectToAsset(newObjective, quest);
                AssetDatabase.SaveAssets();

            }

            EditorGUILayout.LabelField("Objective Data");
            EditorGUILayout.ObjectField("Objective Data", quest, typeof(Objectives), false);

            EditorGUILayout.Space();

            EditorGUILayout.LabelField("Score Range");  

            //apply changes
            serializedObject.ApplyModifiedProperties();
        }
        else
        {
            EditorGUILayout.LabelField("No Quest selected.");
        }
    }
}